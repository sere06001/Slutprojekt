namespace Slutprojekt;
public class BrickPlacer
{
    private readonly List<BaseBrick> bricks = [];
    private readonly BallManager ballManager;

    public BrickPlacer(BallManager ballManager)
    {
        this.ballManager = ballManager;
    }

    public void PlaceBrick(string color, Vector2 position)
    {
        BaseBrick brick = color.ToLower() switch
        {
            "red" => new RedBrick(ballManager) { Position = position },
            "blue" => new BlueBrick(ballManager) { Position = position },
            "green" => new GreenBrick(ballManager) { Position = position },
            "purple" => new PurpleBrick(ballManager) { Position = position },
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
    }

    public void Draw()
    {
        foreach (var brick in bricks)
        {
            brick.Draw();
        }
    }

    public List<BaseBrick> GetBricks() => bricks;
}