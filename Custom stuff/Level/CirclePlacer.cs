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
        int greenCount = circles.Count(c => c is GreenCircle);
        int purpleCount = circles.Count(c => c is PurpleCircle);

        int roll = Globals.Random.Next(1, 21); //Roll 1-20
        string color = roll switch
        {
            <= 4 => "blue",                         //4/20
            <= 6 when purpleCount < 3 => "purple",  //2/20 chance, only if less than 3 purple circles
            <= 7 when greenCount < 2 => "green",    //1/20 chance, only if less than 2 green circles
            _ => "red"                              //Remainder
        };

        if (color == null) color = "red";

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

        circles.RemoveAll(circle => circle.IsMarkedForRemoval);
    }

    public void Draw()
    {
        foreach (var circle in circles)
        {
            circle.Draw();
        }
    }
}