namespace Slutprojekt;
public abstract class BaseBrick
{
    public virtual int ScoreOnHit { get; protected set; }
    public virtual int ScoreMultiplier { get; protected set; } = 1;
    public virtual int ScoreMultiplierDuration { get; protected set; } // In amount of balls shot
    public int Width => TextureCurrent.Width;
    public int Height => TextureCurrent.Height;
    protected Texture2D TextureCurrent { get; set; }
    protected Texture2D TextureHit { get; set; }
    protected Texture2D TextureNotHit { get; set; }
    protected bool Hit { get; set; }
    public virtual Vector2 Position { get; set; }
    public virtual float Rotation { get; set; }
    protected BallManager ballManager { get; set; }

    public BaseBrick(BallManager ballmngr, float rotation)
    {
        ballManager = ballmngr;
        Rotation = rotation;
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
            (int)(Position.X - Width / 2),
            (int)(Position.Y - Height / 2),
            Width,
            Height
        );

        float closestX = MathHelper.Clamp(ball.Position.X, brickBounds.Left, brickBounds.Right);
        float closestY = MathHelper.Clamp(ball.Position.Y, brickBounds.Top, brickBounds.Bottom);

        float distanceX = ball.Position.X - closestX;
        float distanceY = ball.Position.Y - closestY;
        float distanceSquared = (distanceX * distanceX) + (distanceY * distanceY);

        return distanceSquared < (ball.Origin.X * ball.Origin.X);
    }

    private void ResolveBallCollision(Ball ball)
    {
        Vector2 normal = CalculateCollisionNormal(ball);

        ball.Velocity = Vector2.Reflect(ball.Velocity, normal) * ball.Restitution;
        ball.Direction = Vector2.Normalize(ball.Velocity);

        Vector2 closestPoint = GetClosestPointOnBrick(ball);
        float overlap = ball.Origin.X - Vector2.Distance(ball.Position, closestPoint);
        ball.Position += normal * overlap;
    }

    private Vector2 CalculateCollisionNormal(Ball ball)
    {
        Rectangle brickBounds = new Rectangle(
            (int)(Position.X - Width / 2),
            (int)(Position.Y - Height / 2),
            Width,
            Height
        );

        float closestX = MathHelper.Clamp(ball.Position.X, brickBounds.Left, brickBounds.Right);
        float closestY = MathHelper.Clamp(ball.Position.Y, brickBounds.Top, brickBounds.Bottom);

        Vector2 closestPoint = new Vector2(closestX, closestY);
        Vector2 normal = Vector2.Normalize(ball.Position - closestPoint);

        return normal;
    }

    private Vector2 GetClosestPointOnBrick(Ball ball)
    {
        Rectangle brickBounds = new Rectangle(
            (int)(Position.X - Width / 2),
            (int)(Position.Y - Height / 2),
            Width,
            Height
        );

        float closestX = MathHelper.Clamp(ball.Position.X, brickBounds.Left, brickBounds.Right);
        float closestY = MathHelper.Clamp(ball.Position.Y, brickBounds.Top, brickBounds.Bottom);

        return new Vector2(closestX, closestY);
    }

    public void Update()
    {
        CheckCollisions();
        TextureCurrent = Hit ? TextureHit : TextureNotHit;
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(TextureCurrent, Position, null, Color.White, Rotation, new Vector2(Width / 2, Height / 2), 1f, SpriteEffects.None, 0f);
    }
}