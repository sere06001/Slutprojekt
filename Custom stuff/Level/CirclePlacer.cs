namespace Slutprojekt;
public class CirclePlacer
{
    public Player player;
    private List<BaseCircle> circles = new();
    private BallManager ballManager;
    private float slowBallTimer = 0f;

    public CirclePlacer(BallManager ballManager, Player plyr)
    {
        this.ballManager = ballManager;
        player = plyr;
    }

    public List<BaseCircle> GetCircles() => circles;

    public void PlaceCircle(Vector2 position)
    {
        int spacing = 50;
        if (position.Y > Globals.RestrictionCoordsLower - spacing)
        {
            position.Y = Globals.RestrictionCoordsLower - spacing;
        }
        int roll = Globals.Random.Next(1, 101);
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

        BaseCircle circle = color switch
        {
            "red" => new RedCircle(ballManager, player) { Position = position },
            "blue" => new BlueCircle(ballManager, player) { Position = position },
            "green" => new GreenCircle(ballManager, player) { Position = position },
            "purple" => new PurpleCircle(ballManager, player) { Position = position },
            _ => throw new ArgumentException($"Unsupported circle color: {color}")
        };

        circles.Add(circle);
    }

    public void Update()
    {
        foreach (var circle in circles)
        {
            circle.Update();
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
                circles.RemoveAll(circle =>
                {
                    bool toRemove = circle.Hit;
                    if (toRemove)
                    {
                        if (circle is GreenCircle) Globals.placedGreenObjects--;
                        if (circle is PurpleCircle) Globals.placedPurpleObjects--;
                        if (circle is RedCircle) Globals.placedRedObjects--;
                    }
                    return toRemove;
                });
                slowBallTimer = 0f;
            }
        }

        circles.RemoveAll(circle =>
        {
            bool toRemove = circle.IsMarkedForRemoval;
            if (toRemove)
            {
                if (circle is GreenCircle) Globals.placedGreenObjects--;
                if (circle is PurpleCircle) Globals.placedPurpleObjects--;
                if (circle is RedCircle) Globals.placedRedObjects--;
            }
            return toRemove;
        });
    }

    public void Draw()
    {
        foreach (var circle in circles)
        {
            circle.Draw();
        }
    }
}