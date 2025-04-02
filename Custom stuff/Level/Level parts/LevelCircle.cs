namespace Slutprojekt;
public class LevelCircle : LevelBase
{
    protected override Vector2 Position { get; set; }
    private float radius;
    private int circleCount;

    public LevelCircle(BallManager ballmanager, Player plyr, float radius, int circleCount, float centerX, float centerY, bool useBricks) 
        : base(ballmanager, plyr, useBricks)
    {
        this.radius = radius;
        this.circleCount = circleCount;
        player = plyr;
        Position = new Vector2(centerX, centerY);
        CreateCirclePattern(useBricks);
    }

    private void CreateCirclePattern(bool usebricks)
    {
        for (int i = 0; i < circleCount; i++)
        {
            float angle = i * MathHelper.TwoPi / circleCount;
            
            float x = Position.X + radius * (float)Math.Cos(angle);
            float y = Position.Y + radius * (float)Math.Sin(angle);
            UseBrickOrCircle(x, y, usebricks);
        }
    }
    public override void UseBrickOrCircle(float x, float y, bool usebricks)
    {
        if (usebricks)
        {
            float angle = MathF.Atan2(Position.Y - y, Position.X - x);
            float rotation = angle + MathHelper.PiOver2;
            brickPlacer.PlaceBrick(new Vector2(x, y), rotation);
        }
        else
        {
            circlePlacer.PlaceCircle(new Vector2(x, y));
        }
    }
}