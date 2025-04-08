namespace Slutprojekt;
public class CirclePlacer
{
    public Player player;
    private List<BaseCircle> circles = new();
    private BallManager ballManager;

    private static int totalGreenObjects = 0;
    private static int totalPurpleObjects = 0;
    private const int maxGreenObjects = 2;
    private const int maxPurpleObjects = 3;

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
            <= Globals.chanceForRed => "red",
            <= Globals.chanceForPurple when totalPurpleObjects < maxPurpleObjects => "purple",
            <= Globals.chanceForGreen when totalGreenObjects < maxGreenObjects => "green",
            _ => "blue"
        };

        if (color == "green") totalGreenObjects++;
        if (color == "purple") totalPurpleObjects++;

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
                if (circle is GreenCircle) totalGreenObjects--;
                if (circle is PurpleCircle) totalPurpleObjects--;
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