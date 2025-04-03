namespace Slutprojekt;
public class LevelCombiner
{
    public Player player;
    public BallManager ballManager;
    private LevelCircle levelCircle;
    private LevelCircle levelCircle2;
    private LevelCircle levelCircle3;
    public LevelCombiner(BallManager ballmngr, Player plyr)
    {
        ballManager = ballmngr;
        player = plyr;
    }
    public void Face()
    {
        levelCircle = new(ballManager, player, 100f, 10, 500, 500, false);
        levelCircle2 = new(ballManager, player, 100f, 10, 1000, 500, false);
        levelCircle3 = new(ballManager, player, 100f, 10, 1000, 800, true);
    }
    public void Init()
    {
        Face();
    }
    public void Update()
    {
        levelCircle.Update();
        levelCircle2.Update();
        levelCircle3.Update();
    }
    public void Draw()
    {
        levelCircle.Draw();
        levelCircle2.Draw();
        levelCircle3.Draw();
    }
}