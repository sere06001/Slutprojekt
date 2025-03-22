namespace Slutprojekt;
public abstract class BaseCircle
{
    public virtual int ScoreOnHit { get; protected set; }
    public virtual int ScoreMultiplier { get; protected set; } = 1;
    public virtual int ScoreMultiplierDuration { get; protected set; } //In amount of balls shot
    public float Radius => TextureCurrent.Width / 2;
    protected Texture2D TextureCurrent { get; set; }
    protected Texture2D TextureHit { get; set; }
    protected Texture2D TextureNotHit { get; set; }
    protected bool Hit { get; set; }
    public virtual Vector2 Position { get; set; }
    public virtual float Rotation { get; set; }
    public Vector2 Origin => new Vector2(TextureCurrent.Width / 4, TextureCurrent.Height / 4);
    protected BallManager ballManager { get; set; }

    public BaseCircle(BallManager ballmngr)
    {
        ballManager = ballmngr;
    }

    public void CheckCollisions()
    {
        foreach (Ball ball in ballManager.balls)
        {
            if ((ball.Position - (Position + Origin)).Length() < (ball.Origin.X + Radius))
            {
                ResolveBallCollision(ball);
                Hit = true;
            }
        }
    }

    private void ResolveBallCollision(Ball ball)
    {
        Vector2 normal = Vector2.Normalize(ball.Position - (Position + Origin));

        ball.Velocity = Vector2.Reflect(ball.Velocity, normal) * ball.Restitution;
        ball.Direction = Vector2.Normalize(ball.Velocity);

        float overlap = ball.Origin.X + Radius - Vector2.Distance(ball.Position, Position + Origin);
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

    public void Draw()
    {
        Globals.SpriteBatch.Draw(TextureCurrent, Position, null, Color.White, 0f, Origin, 1f, SpriteEffects.None, 0f);
    }
}