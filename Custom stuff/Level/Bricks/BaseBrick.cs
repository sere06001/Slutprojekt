namespace Slutprojekt;
public abstract class BaseBrick
{
    public int Width => TextureCurrent.Width;
    public int Height => TextureCurrent.Height;
    protected Texture2D TextureCurrent { get; set; }
    protected Texture2D TextureHit { get; set; }
    protected Texture2D TextureNotHit { get; set; }
    protected bool Hit { get; set; }
    public virtual Vector2 Position { get; set; }
    protected BallManager ballManager { get; set; }

    public BaseBrick(BallManager ballmngr)
    {
        ballManager = ballmngr;
    }

    public void CheckCollisions()
    {
        foreach (Ball ball in ballManager.balls)
        {
            if (CheckBallCollision(ball))
            {
                ResolveBallCollision(ball);
                Hit = true;
            }
        }
    }

    private bool CheckBallCollision(Ball ball)
    {
        Rectangle brickBounds = new Rectangle(
            (int)(Position.X - Width/2),
            (int)(Position.Y - Height/2),
            Width,
            Height
        );

        // Find closest point on rectangle to circle
        float closestX = MathHelper.Clamp(ball.Position.X, brickBounds.Left, brickBounds.Right);
        float closestY = MathHelper.Clamp(ball.Position.Y, brickBounds.Top, brickBounds.Bottom);

        // Calculate distance between circle center and closest point
        float distanceX = ball.Position.X - closestX;
        float distanceY = ball.Position.Y - closestY;
        float distanceSquared = (distanceX * distanceX) + (distanceY * distanceY);

        return distanceSquared < (ball.Origin.X * ball.Origin.X);
    }

    private void ResolveBallCollision(Ball ball)
    {
        Vector2 normal = CalculateCollisionNormal(ball);
        
        // Reflect ball velocity
        ball.Velocity = Vector2.Reflect(ball.Velocity, normal) * ball.Restitution;
        ball.Direction = Vector2.Normalize(ball.Velocity);
        
        // Move ball out of collision
        float overlap = ball.Origin.X - Vector2.Distance(ball.Position, Position);
        ball.Position += normal * overlap;
    }

    private Vector2 CalculateCollisionNormal(Ball ball)
    {
        Vector2 difference = ball.Position - Position;
        
        // Determine which side of the brick was hit
        if (Math.Abs(difference.X) > Math.Abs(difference.Y))
        {
            return new Vector2(Math.Sign(difference.X), 0);
        }
        return new Vector2(0, Math.Sign(difference.Y));
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

    public void Draw()
    {
        Globals.SpriteBatch.Draw(TextureCurrent, Position, Color.White);
    }
}