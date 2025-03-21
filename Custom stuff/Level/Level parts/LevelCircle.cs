namespace Slutprojekt;
public class LevelCircle : LevelBase
{
    protected override Vector2 Position { get; set; }
    private readonly float radius;
    private readonly int circleCount;

    public LevelCircle(BallManager ballmanager, float radius, int circleCount) 
        : base(ballmanager)
    {
        this.radius = radius;
        this.circleCount = circleCount;
        Position = new Vector2(Globals.Bounds.X / 2, Globals.Bounds.Y / 2);
        CreateCirclePattern();
    }

    private void CreateCirclePattern()
    {
        for (int i = 0; i < circleCount; i++)
        {
            float angle = i * MathHelper.TwoPi / circleCount;
            
            float x = Position.X + radius * (float)Math.Cos(angle);
            float y = Position.Y + radius * (float)Math.Sin(angle);
            
            circlePlacer.PlaceCircle(new Vector2(x, y));
        }
    }

    public override void Draw()
    {
        circlePlacer.Draw();
        brickPlacer.Draw();
    }
}