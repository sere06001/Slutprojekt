namespace Slutprojekt;
public class LevelGenerator
{
    public Player player;
    public BallManager ballManager;
    public LevelBase level;
    public LevelGenerator(BallManager ballmngr, Player plyr)
    {
        ballManager = ballmngr;
        player = plyr;
    }
    public void Face()
    {
        LevelCircle levelCircle = new(ballManager, player, 100f, 10, 500, 500, false);
        LevelGrid levelGrid = new(ballManager, player, 1, 10, 100, 250, 250, true);
        
    }
    public void Update()
    {
        level.Update();
    }
    public void Draw()
    {
        level.Draw();
    }
}