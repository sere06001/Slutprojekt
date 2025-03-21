namespace Slutprojekt;
public class BrickPlacer
{
    private readonly List<BaseBrick> bricks = new();
    private readonly BallManager ballManager;

    public BrickPlacer(BallManager ballManager)
    {
        this.ballManager = ballManager;
    }

    public void PlaceBrick(Vector2 position)
    {
        int greenCount = bricks.Count(b => b is GreenBrick);
        int purpleCount = bricks.Count(b => b is PurpleBrick);

        int roll = Globals.Random.Next(1, 21); // Roll 1-20
        string color = roll switch
        {
            <= 4 => "blue",                         //4/20
            <= 6 when purpleCount < 3 => "purple",  //2/20 chance, only if less than 3 purple circles
            <= 7 when greenCount < 2 => "green",    //1/20 chance, only if less than 2 green circles
            _ => "red"                              //Remainder
        };

        if (color == null) color = "red";

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