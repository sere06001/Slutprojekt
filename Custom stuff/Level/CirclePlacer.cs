namespace Slutprojekt;
public class CirclePlacer
{
    private readonly List<BaseCircle> circles = [];
    private readonly BallManager ballManager;

    public CirclePlacer(BallManager ballManager)
    {
        this.ballManager = ballManager;
    }

    public void PlaceCircle(string color, Vector2 position)
    {
        BaseCircle circle = color.ToLower() switch
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