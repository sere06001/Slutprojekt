namespace Slutprojekt;
public class LevelCombiner
{
    public Player player;
    public BallManager ballManager;
    public List<LevelGrid> levelGrids = new List<LevelGrid>();
    private TeleporterManager teleporterManager;

    public LevelCombiner(BallManager ballmngr, Player plyr)
    {
        ballManager = ballmngr;
        player = plyr;
        teleporterManager = new TeleporterManager(ballManager);
    }

    public void UnevenCircleGrid()
    {
        levelGrids.Clear();

        // Add some example teleporters
        teleporterManager.AddTeleporterPair(
            new Vector2(Globals.LeftWall + 50, 200),
            new Vector2(Globals.RightWall - 50, 200)
        );

        for (int i = 0; i < 8; i++)
        {
            int varyingOffset = (i % 2 == 0) ? 10 : -10;

            levelGrids.Add(new LevelGrid(ballManager, player, 1, 12, 
                Globals.BallBlue.Width * 2f + 4, 
                Globals.Bounds.X / 2 + varyingOffset, 
                Globals.Bounds.Y * 0.3f + 40*i, false, false));
        }
    }

    public void Init()
    {
        UnevenCircleGrid();
    }

    public void Update()
    {
        foreach (var grid in levelGrids)
        {
            grid.Update();
        }
        teleporterManager.Update();
    }

    public void Draw()
    {
        foreach (var grid in levelGrids)
        {
            grid.Draw();
        }
        teleporterManager.Draw();
    }
}
