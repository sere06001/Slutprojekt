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
    public void MoveLevelConstSpeed(Vector2 UpperLeftBounds, Vector2 LowerRightBounds, 
    float speed)
    {

    }
    public void MoveLevelVaryingSpeed(Vector2 UpperLeftBounds, Vector2 LowerRightBounds, 
    float lowestSpeed, float highestSpeed)
    {

    }
}