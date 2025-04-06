namespace Slutprojekt;
public abstract class LevelMovingBase : LevelBase
{
    public LevelMovingBase(BallManager ballmanager, Player plyr, bool useBricks) 
        : base(ballmanager, plyr, useBricks)
    {
        player = plyr;
        ballManager = ballmanager;
        UseBricks = useBricks;
    }
}