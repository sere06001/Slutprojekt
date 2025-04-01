namespace Slutprojekt;
public class BrickPlacer
{
    public List<BaseBrick> bricks = new();
    private BallManager ballManager;

    public BrickPlacer(BallManager ballManager)
    {
        this.ballManager = ballManager;
    }

    public void PlaceBrick(Vector2 position, float rotation)
    {
        int greenCount = bricks.Count(b => b is GreenBrick);
        int purpleCount = bricks.Count(b => b is PurpleBrick);

        int roll = Globals.Random.Next(1, 21); //Roll 1-20
        string color = roll switch
        {
            <= 4 => "blue",                         //4/20
            <= 6 when purpleCount < 3 => "purple",  //2/20 chance, only if less than 3 purple bricks
            <= 7 when greenCount < 2 => "green",    //1/20 chance, only if less than 2 green bricks
            _ => "red"                              //Remainder
        };

        if (color == null) color = "red";

        BaseBrick brick = color switch
        {
            "red" => new RedBrick(ballManager, rotation) { Position = position },
            "blue" => new BlueBrick(ballManager, rotation) { Position = position },
            "green" => new GreenBrick(ballManager, rotation) { Position = position },
            "purple" => new PurpleBrick(ballManager, rotation) { Position = position },
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

        bricks.RemoveAll(brick => brick.IsMarkedForRemoval);
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