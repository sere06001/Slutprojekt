namespace Slutprojekt;
public class LevelCombiner
{
    public Player player;
    public BallManager ballManager;
    private List<LevelGrid> levelGrids = new List<LevelGrid>();

    public LevelCombiner(BallManager ballmngr, Player plyr)
    {
        ballManager = ballmngr;
        player = plyr;
    }

    public void UnevenCircleGrid()
    {
        levelGrids.Clear();

        for (int i = 0; i < 10; i++)
        {
            int varyingOffset = (i % 2 == 0) ? 10 : -10;

            levelGrids.Add(new LevelGrid(ballManager, player, 1, 25, 
                Globals.BallBlue.Width * 2f + 4, 
                Globals.Bounds.X / 2 + varyingOffset, 
                Globals.Bounds.Y * 0.2f + 50*i, false));
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
    }

    public void Draw()
    {
        foreach (var grid in levelGrids)
        {
            grid.Draw();
        }
    }
}
