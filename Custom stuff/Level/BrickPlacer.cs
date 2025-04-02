namespace Slutprojekt;
public class BrickPlacer
{
    public Player player;
    private List<BaseBrick> bricks = new();
    private BallManager ballManager;

    public BrickPlacer(BallManager ballManager, Player plyr)
    {
        this.ballManager = ballManager;
        player = plyr;
    }
    public List<BaseBrick> GetBricks() => bricks;

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
            "red" => new RedBrick(ballManager, player, rotation) { Position = position },
            "blue" => new BlueBrick(ballManager, player, rotation) { Position = position },
            "green" => new GreenBrick(ballManager, player, rotation) { Position = position },
            "purple" => new PurpleBrick(ballManager, player, rotation) { Position = position },
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
}