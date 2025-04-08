namespace Slutprojekt;

public class BrickPlacer
{
    public Player player;
    private List<BaseBrick> bricks = new();
    private BallManager ballManager;

    private static int totalGreenObjects = 0;
    private static int totalPurpleObjects = 0;

    public BrickPlacer(BallManager ballManager, Player plyr)
    {
        this.ballManager = ballManager;
        player = plyr;
    }

    public List<BaseBrick> GetBricks() => bricks;

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
            <= Globals.chanceForRed => "red",
            <= Globals.chanceForPurple when totalPurpleObjects < Globals.maxPurpleObjects => "purple",
            <= Globals.chanceForGreen when totalGreenObjects < Globals.maxGreenObjects => "green",
            _ => "blue"
        };

        if (color == "green") totalGreenObjects++;
        if (color == "purple") totalPurpleObjects++;

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

        bricks.RemoveAll(brick =>
        {
            bool toRemove = brick.IsMarkedForRemoval;
            if (toRemove)
            {
                if (brick is GreenBrick) totalGreenObjects--;
                if (brick is PurpleBrick) totalPurpleObjects--;
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