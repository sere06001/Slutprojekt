namespace Slutprojekt;
public abstract class BaseCircle
{
    public float Radius => TextureCurrent.Width / 2;
    protected Texture2D TextureCurrent { get; set; }
    protected Texture2D TextureHit { get; set; }
    protected Texture2D TextureNotHit { get; set; }
    protected bool Hit { get; set; }
    public virtual Vector2 Position { get; set; }
    protected BallManager ballManager { get; set; }

    public BaseCircle(BallManager ballmngr)
    {
        ballManager = ballmngr;
    }

    public void CheckCollisions()
    {
        foreach (Ball ball in ballManager.balls)
        {
            if ((ball.Position - Position).Length() < (ball.Origin.X + Radius))
            {
                ResolveBallCollision(ball);
                Hit = true;
            }
        }
    }

    private void ResolveBallCollision(Ball ball)
    {
        // Calculate normal from circle center to ball
        Vector2 normal = Vector2.Normalize(ball.Position - Position);
        
        // Reflect ball velocity
        ball.Velocity = Vector2.Reflect(ball.Velocity, normal) * ball.Restitution;
        ball.Direction = Vector2.Normalize(ball.Velocity);
        
        // Move ball out of collision
        float overlap = (ball.Origin.X + Radius) - Vector2.Distance(ball.Position, Position);
        ball.Position += normal * overlap;
    }

    public void Update()
    {
        CheckCollisions();
        if (Hit)
        {
            TextureCurrent = TextureHit;
        }
        else
        {
            TextureCurrent = TextureNotHit;
        }
    }

    public abstract void Draw();
}