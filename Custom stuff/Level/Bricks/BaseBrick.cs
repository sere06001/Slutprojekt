namespace Slutprojekt;
public abstract class BaseBrick
{
    public virtual int ScoreOnHit { get; protected set; }
    public virtual int ScoreMultiplier { get; protected set; } = 1;
    private float scoreDisplayTimer = 0f;
    private float ScoreDisplayDurationSeconds = 2.5f;
    private bool showScore = false;
    private bool hasShownScore = false;
    private float secondsBeforeRemovalTimer = 0f;
    private float secondsBeforeRemoval = 5f;
    public int Width => TextureCurrent.Width;
    public int Height => TextureCurrent.Height;
    protected Texture2D TextureCurrent { get; set; }
    protected Texture2D TextureHit { get; set; }
    protected Texture2D TextureNotHit { get; set; }
    protected bool Hit { get; set; }
    public virtual Vector2 Position { get; set; }
    public virtual float Rotation { get; set; }
    protected BallManager ballManager { get; set; }

    public bool IsMarkedForRemoval { get; private set; } = false;

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

                secondsBeforeRemovalTimer = secondsBeforeRemoval;
            }
        }
    }

    private bool CheckBallCollision(Ball ball)
    {
        Vector2 rotatedBallPos = RotatePoint(ball.Position, Position, -Rotation);

        Rectangle brickBounds = new Rectangle(
            (int)(Position.X - Width / 2),
            (int)(Position.Y - Height / 2),
            Width,
            Height
        );

        float closestX = MathHelper.Clamp(rotatedBallPos.X, brickBounds.Left, brickBounds.Right);
        float closestY = MathHelper.Clamp(rotatedBallPos.Y, brickBounds.Top, brickBounds.Bottom);

        float distanceX = rotatedBallPos.X - closestX;
        float distanceY = rotatedBallPos.Y - closestY;
        float distanceSquared = (distanceX * distanceX) + (distanceY * distanceY);

        return distanceSquared < (ball.Origin.X * ball.Origin.X);
    }

    private Vector2 CalculateCollisionNormal(Ball ball)
    {
        Vector2 rotatedBallPos = RotatePoint(ball.Position, Position, -Rotation);

        Rectangle brickBounds = new Rectangle(
            (int)(Position.X - Width / 2),
            (int)(Position.Y - Height / 2),
            Width,
            Height
        );

        float closestX = MathHelper.Clamp(rotatedBallPos.X, brickBounds.Left, brickBounds.Right);
        float closestY = MathHelper.Clamp(rotatedBallPos.Y, brickBounds.Top, brickBounds.Bottom);

        Vector2 closestPoint = new Vector2(closestX, closestY);
        Vector2 normal = Vector2.Normalize(rotatedBallPos - closestPoint);

        return RotateVector(normal, Rotation);
    }

    private void ResolveBallCollision(Ball ball)
    {
        Vector2 normal = CalculateCollisionNormal(ball);

        ball.Velocity = Vector2.Reflect(ball.Velocity, normal) * ball.Restitution;
        ball.Direction = Vector2.Normalize(ball.Velocity);

        Vector2 closestPoint = GetClosestPointOnBrick(ball);
        float overlap = ball.Origin.X - Vector2.Distance(ball.Position, closestPoint);
        ball.Position += normal * overlap;

        showScore = true;
        scoreDisplayTimer = ScoreDisplayDurationSeconds;
    }

    private Vector2 GetClosestPointOnBrick(Ball ball)
    {
        Vector2 rotatedBallPos = RotatePoint(ball.Position, Position, -Rotation);

        Rectangle brickBounds = new Rectangle(
            (int)(Position.X - Width / 2),
            (int)(Position.Y - Height / 2),
            Width,
            Height
        );

        float closestX = MathHelper.Clamp(rotatedBallPos.X, brickBounds.Left, brickBounds.Right);
        float closestY = MathHelper.Clamp(rotatedBallPos.Y, brickBounds.Top, brickBounds.Bottom);

        Vector2 closestPoint = new Vector2(closestX, closestY);

        return RotatePoint(closestPoint, Position, Rotation);
    }

    private Vector2 RotatePoint(Vector2 point, Vector2 origin, float angle)
    {
        float translatedX = point.X - origin.X;
        float translatedY = point.Y - origin.Y;

        float rotatedX = translatedX * MathF.Cos(angle) - translatedY * MathF.Sin(angle);
        float rotatedY = translatedX * MathF.Sin(angle) + translatedY * MathF.Cos(angle);

        return new Vector2(rotatedX + origin.X, rotatedY + origin.Y);
    }

    private Vector2 RotateVector(Vector2 vector, float angle)
    {
        float rotatedX = vector.X * MathF.Cos(angle) - vector.Y * MathF.Sin(angle);
        float rotatedY = vector.X * MathF.Sin(angle) + vector.Y * MathF.Cos(angle);
        return new Vector2(rotatedX, rotatedY);
    }

    public void Update()
    {
        CheckCollisions();

        if (Hit)
        {
            secondsBeforeRemovalTimer -= Globals.TotalSeconds;

            if (secondsBeforeRemovalTimer <= 0)
            {
                IsMarkedForRemoval = true;
                return;
            }
        }

        TextureCurrent = Hit ? TextureHit : TextureNotHit;

        if (showScore && !hasShownScore)
        {
            scoreDisplayTimer -= Globals.TotalSeconds;
            if (scoreDisplayTimer <= 0)
            {
                showScore = false;
                hasShownScore = true;
            }
        }
    }

    public void Draw()
    {
        if (IsMarkedForRemoval)
        {
            return;
        }

        Globals.SpriteBatch.Draw(TextureCurrent, Position, null, Color.White, Rotation, new Vector2(Width / 2, Height / 2), 1f, SpriteEffects.None, 0f);

        if (showScore && !hasShownScore)
        {
            DrawScore();
        }
    }

    public void DrawScore()
    {
        if (showScore && scoreDisplayTimer > 0)
        {
            string score = ScoreOnHit.ToString();

            Vector2 pos = Position + new Vector2(0, -TextureHit.Height * 2 - 10);
            Vector2 textOrigin = new Vector2(Globals.Font.MeasureString(score).X / 2, 0);
            Globals.SpriteBatch.DrawString(Globals.Font, score, pos, Color.White, 0f, textOrigin, 1f, SpriteEffects.None, 0f);
        }
    }
}