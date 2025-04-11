namespace Slutprojekt;
public class LevelCombiner
{
    public Player player;
    public BallManager ballManager;
    public List<LevelBase> levels = new List<LevelBase>();
    private TeleporterManager teleporterManager;
    public LevelCombiner(BallManager ballmngr, Player plyr)
    {
        ballManager = ballmngr;
        player = plyr;
        teleporterManager = new TeleporterManager(ballManager);
    }
    public void Reset()
    {
        levels.Clear();
        teleporterManager = new TeleporterManager(ballManager);
    }
    public void SecondLevel()
    {
        levels.Add(new LevelCircle(ballManager, player, 
            250, 11, 
            Globals.Bounds.X / 4-15, 
            Globals.Bounds.Y / 2, 
            true, false, 0.4f, (float)Math.PI/1.90f));
        levels.Add(new LevelCircle(ballManager, player, 
            250, 11, 
            Globals.Bounds.X / 4*3-15, 
            Globals.Bounds.Y / 2, 
            true, false, 
            (float)Math.PI/2 + 0.4f,
            (float)Math.PI/2 + (float)Math.PI/1.90f));
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

            levels.Add(new LevelGrid(ballManager, player, 1, 12, 
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
        foreach (var level in levels)
        {
            level.Update();
        }
        teleporterManager.Update();

    }

    public void Draw()
    {
        foreach (var level in levels)
        {
            level.Draw();
        }
        teleporterManager.Draw();

    }
}
