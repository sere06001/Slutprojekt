namespace Slutprojekt;
public class BrickPlacer
{
    private readonly List<BaseBrick> bricks = [];
    private readonly BallManager ballManager;

    public BrickPlacer(BallManager ballManager)
    {
        this.ballManager = ballManager;
    }

    public void PlaceBrick(Vector2 position)
    {
        int roll = Globals.Random.Next(1, 21); // Roll 1-20
        string color = roll switch
        {
            <= 4 => "blue",    // 4/20 = 1/5 chance
            <= 6 => "purple",  // 2/20 = 1/10 chance
            <= 7 => "green",   // 1/20 chance
            _ => "red"         // 13/20 chance (remainder)
        };

        BaseBrick brick = color switch
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