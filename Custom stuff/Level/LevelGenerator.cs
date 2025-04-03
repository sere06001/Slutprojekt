namespace Slutprojekt;
public class LevelGenerator
{
    public Player player;
    public BallManager ballManager;
    private LevelCombiner levelCombiner;
    private LevelCircle levelCircle;
    private LevelCircle levelCircle2;
    private LevelCircle levelCircle3;
    public LevelGenerator(BallManager ballmngr, Player plyr, LevelCombiner lvlcombiner)
    {
        ballManager = ballmngr;
        player = plyr;
        levelCombiner = lvlcombiner;
    }
    public void Init()
    {
        levelCombiner.Face();
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