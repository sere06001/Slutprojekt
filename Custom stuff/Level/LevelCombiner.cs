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
    public void GetLevel(int levelID)
    {
        switch (levelID)
        {
            case 0:
                FirstLevel();
                break;
            case 1:
                SecondLevel();
                break;
            default:
                break;
        }
    }
    public void Reset()
    {
        levels.Clear();
        circlePlacer.Reset();
        brickPlacer.Reset();
        Globals.ResetColouredObjects();
        teleporterManager = new TeleporterManager(ballManager);
    }
    public void FirstLevel()
    {
        for (int i = 0; i < 8; i++)
        {
            int varyingOffset = (i % 2 == 0) ? 10 : -10;

            levels.Add(new LevelGrid(ballManager, player, 1, 12, 
                Globals.BallBlue.Width * 2f + 4, Globals.Bounds.X / 2 + varyingOffset, 
                Globals.Bounds.Y * 0.3f + 40*i, false, false));
        }
    }
    public void SecondLevel()
    {
        levels.Add(new LevelCircle(ballManager, player, 250, 9, Globals.LeftWall + 5, 100, 
            true, false, 34.4f, 95f));



        levels.Add(new LevelCircle(ballManager, player, 250, 9, Globals.RightWall - 9, 100, 
            true, false, 91.4f, 152f));



        levels.Add(new LevelCircle(ballManager, player, 250, 4, Globals.RightWall - 9, 660, 
            true, false, 248.4f, 275.4f));
            
        levels.Add(new LevelCircle(ballManager, player, 250, 4, Globals.RightWall - 212, 202, 
            true, false, 70.6f, 97.6f));



        levels.Add(new LevelCircle(ballManager, player, 250, 4, Globals.LeftWall + 14, 660, 
            true, false, 270.4f, 297.4f));

        levels.Add(new LevelCircle(ballManager, player, 250, 4, Globals.LeftWall + 209, 199, 
            true, false, 88.4f, 115.4f));


        for (int i = 0; i < 4; i++)
        {
            levels.Add(new LevelGrid(ballManager, player, 1, 4 - i, 
                Globals.BallBlue.Width * 2f + 4, Globals.LeftWall + 100 - i * 25, 
                180+i*40, false, false, 30));
        }

        for (int i = 0; i < 4; i++)
        {
            levels.Add(new LevelGrid(ballManager, player, 1, 4-i, 
                Globals.BallBlue.Width * 2f + 4, Globals.RightWall - 110 + i * 25, 
                180+i*40, false, false, -30));
        }


        for (int i = 0; i < 4; i++)
        {
            levels.Add(new LevelGrid(ballManager, player, 1, i+3, 
                Globals.BallBlue.Width * 2.5f + 5*i, Globals.Bounds.X / 2 - 5, 
                260+i*40, false, false));
        }


        
        levels.Add(new LevelGrid(ballManager, player, 1, 7, 
            Globals.BallBlue.Width * 2f + 4, Globals.LeftWall + 150, 
            475, false, false, 7));
        levels.Add(new LevelGrid(ballManager, player, 1, 7, 
            Globals.BallBlue.Width * 2f + 4, Globals.RightWall - 160, 
            475, false, false, -7));
        circlePlacer.PlaceCircle(new (Globals.Bounds.X / 2-5, 485));



        levels.Add(new LevelGrid(ballManager, player, 1, 3, 
            Globals.BallBlue.Width * 2f + 15, Globals.Bounds.X / 2 - 5, 
            440, false, false));


        levels.Add(new LevelGrid(ballManager, player, 1, 2, 
            Globals.BallBlue.Width * 2f + 4, Globals.LeftWall + 90, 
            370, false, false, -7));

        levels.Add(new LevelGrid(ballManager, player, 1, 2, 
            Globals.BallBlue.Width * 2f + 4, Globals.RightWall - 95, 
            370, false, false, 7));

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
