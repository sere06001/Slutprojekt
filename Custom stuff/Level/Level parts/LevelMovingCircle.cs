namespace Slutprojekt;
public class LevelMovingCircle : LevelMovingBase
{
    public LevelMovingCircle(BallManager ballmng, Player player, bool useBricks) : base(ballmng, player, useBricks)
    {
        ballManager = ballmng;
        UseBricks = useBricks;
    }
}