namespace Slutprojekt;
public class CirclePlacer
{
    private readonly List<BaseCircle> circles = [];
    private readonly BallManager ballManager;

    public CirclePlacer(BallManager ballManager)
    {
        this.ballManager = ballManager;
    }

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
            "red" => new RedCircle(ballManager) { Position = position },
            "blue" => new BlueCircle(ballManager) { Position = position },
            "green" => new GreenCircle(ballManager) { Position = position },
            "purple" => new PurpleCircle(ballManager) { Position = position },
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
    }

    public void Draw()
    {
        foreach (var circle in circles)
        {
            circle.Draw();
        }
    }

    public List<BaseCircle> GetCircles() => circles;
}