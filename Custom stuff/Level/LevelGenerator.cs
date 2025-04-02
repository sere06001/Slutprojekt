namespace Slutprojekt;
public class LevelGenerator
{
    public Player player;
    public BallManager ballManager;
    public LevelGenerator(BallManager ballmngr, Player plyr)
    {
        ballManager = ballmngr;
        player = plyr;
    }
    public void Face()
    {
        LevelCircle levelCircle = new(ballManager, player, 100f, 10, 500, 500, false);
    }
}