namespace Slutprojekt;
public class LevelGenerator
{
    public Player player;
    public BallManager ballManager;
    private LevelCombiner levelCombiner;
    public LevelGenerator(BallManager ballmngr, Player plyr, LevelCombiner lvlcombiner)
    {
        ballManager = ballmngr;
        player = plyr;
        levelCombiner = lvlcombiner;
    }
    public void Init()
    {
        levelCombiner.Init();
    }
    public void Update()
    {
        levelCombiner.Update();
    }
    public void Draw()
    {
        levelCombiner.Draw();
    }
}