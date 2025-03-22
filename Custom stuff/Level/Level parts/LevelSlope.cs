namespace Slutprojekt;
public class LevelSlope : LevelBase
{
    protected override Vector2 Position { get; set; }
    public LevelSlope (BallManager ballmanager, bool useBricks) : base(ballmanager, useBricks)
    {
        
    }
}