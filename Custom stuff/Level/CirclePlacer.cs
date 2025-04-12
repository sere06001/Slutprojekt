namespace Slutprojekt;
public class CirclePlacer
{
    public Player player;
    private List<BaseCircle> circles = new();
    private BallManager ballManager;

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