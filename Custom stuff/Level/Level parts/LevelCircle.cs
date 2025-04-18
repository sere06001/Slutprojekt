namespace Slutprojekt;
public class LevelCircle : LevelBase
{
    protected override Vector2 Position { get; set; }
    private float radius;
    private int circleCount;
    private float startAngle;
    private float endAngle;

    public LevelCircle(BallManager ballmanager, Player plyr, float radius, int circleCount, 
        float centerX, float centerY, bool useBricks, bool move, 
        float startAngle = 0f, float endAngle = 360f) 
        : base(ballmanager, plyr, centerX, centerY, useBricks, move)
    {
        this.radius = radius;
        this.circleCount = circleCount;
        this.startAngle = startAngle * ((float)Math.PI / 180f);
        this.endAngle = endAngle * ((float)Math.PI / 180f);
        CreateCirclePattern(useBricks);
    }

    private void CreateCirclePattern(bool usebricks)
    {
        float angleStep = (endAngle - startAngle) / circleCount;
        
        for (int i = 0; i < circleCount; i++)
        {
            float angle = startAngle + (i * angleStep);
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