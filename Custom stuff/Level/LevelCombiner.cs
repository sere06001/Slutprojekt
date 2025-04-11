namespace Slutprojekt;
public class LevelCombiner
{
    public Player player;
    public BallManager ballManager;
    public List<LevelGrid> levelGrids = new List<LevelGrid>();
    public LevelCircle levelCircle;
    private TeleporterManager teleporterManager;
    public LevelCombiner(BallManager ballmngr, Player plyr)
    {
        ballManager = ballmngr;
        player = plyr;
        teleporterManager = new TeleporterManager(ballManager);
    }
    public void Reset()
    {
        levelGrids.Clear();
        teleporterManager = new TeleporterManager(ballManager);
    }
    public void SecondLevel()
    {
        levelCircle = new LevelCircle(ballManager, player, 
            250, 10, 
            Globals.Bounds.X / 4, 
            Globals.Bounds.Y / 2, 
            true, false, 0.3f, (float)Math.PI/2f);
    }

    public void FirstLevel()
    {

        teleporterManager.AddTeleporterPair(
            new Vector2(Globals.LeftWall + 50, 200),
            new Vector2(Globals.RightWall - 50, 200)
        );

        for (int i = 0; i < 8; i++)
        {
            int varyingOffset = (i % 2 == 0) ? 10 : -10;

            levelGrids.Add(new LevelGrid(ballManager, player, 1, 12, 
                Globals.BallBlue.Width * 1.5f + 4, 
                Globals.Bounds.X / 2 + varyingOffset, 
                Globals.Bounds.Y * 0.3f + 40*i, false, false));
        }
    }

    public void Init()
    {
        Reset();
        SecondLevel();
    }

    public void Update()
    {
        foreach (var grid in levelGrids)
        {
            grid.Update();
        }
        teleporterManager.Update();

        levelCircle.Update();
    }

    public void Draw()
    {
        foreach (var grid in levelGrids)
        {
            grid.Draw();
        }
        teleporterManager.Draw();

        levelCircle.Draw();
    }
}
