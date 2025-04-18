namespace Slutprojekt;
public class LevelCombiner
{
    public Player player;
    public BallManager ballManager;
    public List<LevelBase> levels = new List<LevelBase>();
    public CirclePlacer circlePlacer;
    public BrickPlacer brickPlacer;
    private TeleporterManager teleporterManager;
    public LevelCombiner(BallManager ballmngr, Player plyr)
    {
        ballManager = ballmngr;
        player = plyr;
        teleporterManager = new TeleporterManager(ballManager);
        circlePlacer = new CirclePlacer(ballManager, player);
        brickPlacer = new BrickPlacer(ballManager, player);
    }
    public void Reset()
    {
        levels.Clear();
        teleporterManager = new TeleporterManager(ballManager);
    }
    public void FirstLevel()
    {
        for (int i = 0; i < 8; i++)
        {
            int varyingOffset = (i % 2 == 0) ? 10 : -10;

            levels.Add(new LevelGrid(ballManager, player, 1, 12, 
                Globals.BallBlue.Width * 2f + 4, 
                Globals.Bounds.X / 2 + varyingOffset, 
                Globals.Bounds.Y * 0.3f + 40*i, false, false));
        }
    }
    public void SecondLevel()
    {
        levels.Add(new LevelCircle(ballManager, player, 
            250, 9, 
            Globals.LeftWall + 5, 
            100, 
            true, false, 
            34.4f, 
            95f));



        levels.Add(new LevelCircle(ballManager, player, 
            250, 9, 
            Globals.RightWall - 9, 
            100, 
            true, false, 
            91.4f,
            152f));



        levels.Add(new LevelCircle(ballManager, player, 
            250, 4, 
            Globals.RightWall - 9, 
            660, 
            true, false,
            248.4f,
            275.4f));
            
        levels.Add(new LevelCircle(ballManager, player, 
            250, 4, 
            Globals.RightWall - 212, 
            202, 
            true, false,
            70.6f,
            97.6f));



        levels.Add(new LevelCircle(ballManager, player, 
            250, 4, 
            Globals.LeftWall + 14, 
            660, 
            true, false,
            270.4f,
            297.4f));

        levels.Add(new LevelCircle(ballManager, player, 
            250, 4, 
            Globals.LeftWall + 209, 
            199, 
            true, false,
            88.4f,
            115.4f));



        circlePlacer.PlaceCircle(new Vector2(250, 200));
    }

    public void Init()
    {
        Reset();
        SecondLevel();
    }
    public void DebugUI()
    {
        int totalObjectCount;
        totalObjectCount = brickPlacer.GetBricks().Count + circlePlacer.GetCircles().Count;
        foreach (var level in levels)
        {
            totalObjectCount += level.brickPlacer.GetBricks().Count;
            totalObjectCount += level.circlePlacer.GetCircles().Count;
        }
        Globals.SpriteBatch.DrawString(Globals.Font, $"Placed object count: {totalObjectCount}", new(100, 125), Color.White);
    }
    public void Update()
    {
        foreach (var level in levels)
        {
            level.Update();
        }
        circlePlacer.Update();
        brickPlacer.Update();
        teleporterManager.Update();

    }

    public void Draw()
    {
        foreach (var level in levels)
        {
            level.Draw();
        }
        circlePlacer.Draw();
        brickPlacer.Draw();
        teleporterManager.Draw();
        DebugUI();
    }
}
