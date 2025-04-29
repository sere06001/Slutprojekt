namespace Slutprojekt;

public class BrickPlacer
{
    public Player player;
    private List<BaseBrick> bricks = new();
    private BallManager ballManager;

    private float slowBallTimer = 0f;

    public BrickPlacer(BallManager ballManager, Player plyr)
    {
        this.ballManager = ballManager;
        player = plyr;
    }

    public List<BaseBrick> GetBricks() => bricks;
    public void Reset()
    {
        bricks.Clear();
        slowBallTimer = 0f;
    }
    public void PlaceBrick(Vector2 position, float rotation = 0)
    {
        int spacing = 50;
        if (position.Y > Globals.RestrictionCoordsLower - spacing)
        {
            position.Y = Globals.RestrictionCoordsLower - spacing;
        }
        int roll = Globals.Random.Next(1, Globals.upperBoundForBricksNCircles);
        string color = roll switch
        {
            <= Globals.chanceForRed when Globals.placedRedObjects < Globals.maxRedObjects => "red",
            <= Globals.chanceForPurple when Globals.placedPurpleObjects < Globals.maxPurpleObjects => "purple",
            <= Globals.chanceForGreen when Globals.placedGreenObjects < Globals.maxGreenObjects => "green",
            _ => "blue"
        };

        if (color == "green") Globals.placedGreenObjects++;
        if (color == "purple") Globals.placedPurpleObjects++;
        if (color == "red") Globals.placedRedObjects++;

        BaseBrick brick = color switch
        {
            "red" => new RedBrick(ballManager, player, rotation) { Position = position },
            "blue" => new BlueBrick(ballManager, player, rotation) { Position = position },
            "green" => new GreenBrick(ballManager, player, rotation) { Position = position },
            "purple" => new PurpleBrick(ballManager, player, rotation) { Position = position },
            _ => throw new ArgumentException($"Unsupported brick color: {color}")
        };

        bricks.Add(brick);
    }

    public void Update()
    {
        foreach (var brick in bricks)
        {
            brick.Update();
        }
        
        bool areAllBallsStuck = ballManager.balls.Count > 0;
        foreach (Ball ball in ballManager.balls)
        {
            if (ball.Velocity.Length() >= Globals.minBallSpeed)
            {
                areAllBallsStuck = false;
                slowBallTimer = 0f;
                break;
            }
        }

        if (areAllBallsStuck)
        {
            slowBallTimer += Globals.TotalSeconds;
            if (slowBallTimer >= Globals.stuckTimeThreshold)
            {
                bricks.RemoveAll(brick =>
                {
                    bool toRemove = brick.Hit;
                    if (toRemove)
                    {
                        if (brick is GreenBrick) Globals.placedGreenObjects--;
                        if (brick is PurpleBrick) Globals.placedPurpleObjects--;
                        if (brick is RedBrick) Globals.placedRedObjects--;
                    }
                    return toRemove;
                });
                slowBallTimer = 0f;
            }
        }

        bricks.RemoveAll(brick =>
        {
            bool toRemove = brick.IsMarkedForRemoval;
            if (toRemove)
            {
                if (brick is GreenBrick) Globals.placedGreenObjects--;
                if (brick is PurpleBrick) Globals.placedPurpleObjects--;
                if (brick is RedBrick) Globals.placedRedObjects--;
            }
            return toRemove;
        });
    }

    public void Draw()
    {
        foreach (var brick in bricks)
        {
            brick.Draw();
        }
    }
}