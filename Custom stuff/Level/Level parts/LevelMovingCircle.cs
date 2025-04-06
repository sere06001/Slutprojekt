namespace Slutprojekt;
public class LevelMovingCircle : LevelMovingBase
{
    protected override Vector2 Position { get; set; }
    private float radius;
    private int circleCount;
    public LevelMovingCircle(BallManager ballmng, Player player, bool useBricks) : base(ballmng, player, useBricks)
    {

    }
}