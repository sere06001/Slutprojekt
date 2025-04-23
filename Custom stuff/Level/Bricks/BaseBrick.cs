namespace Slutprojekt;
public abstract class BaseBrick
{
    public Player player;
    public virtual int ScoreOnHit { get; protected set; }
    public virtual int ScoreMultiplier { get; protected set; } = 1;
    private string scoreToDisplay = "0";
    private bool getScoreToDisplay = true;
    protected float scoreDisplayTimer = 0f;
    protected float ScoreDisplayDurationSeconds = 2.5f;
    protected bool showScore = false;
    protected bool hasShownScore = false;
    protected float secondsBeforeRemovalTimer = 0.5f;
    protected float secondsBeforeRemoval = 30f;
    public int Width => TextureCurrent.Width;
    public int Height => TextureCurrent.Height;
    protected Texture2D TextureCurrent { get; set; }
    protected Texture2D TextureHit { get; set; }
    protected Texture2D TextureNotHit { get; set; }
    public bool Hit { get; set; }
    public virtual Vector2 Position { get; set; }
    public virtual float Rotation { get; set; }
    protected BallManager ballManager { get; set; }

    public bool IsMarkedForRemoval { get; protected set; } = false;
    protected bool hasContributedToPowerup = false;

    public BaseBrick(BallManager ballmngr, Player plyr, float rotation)
    {
        ballManager = ballmngr;
        player = plyr;
        Rotation = rotation;
    }

    protected virtual void CheckCollisions()
    {
        foreach (Ball ball in ballManager.balls)
        {
            if (CheckBallCollision(ball))
            {
                ball.HasHit();
                if (!Hit)
                {
                    SetHit();
                    ball.IncreaseHitCount(player);
                }
                if (ball.IsOnFire)
                {
                    IsMarkedForRemoval = true;
                }
                else
                {
                    ResolveBallCollision(ball);
                }
            }
        }
    }

    public void SetHit()
    {
        Hit = true;
        player.AddCircleAndBricksHitCount();
        player.AddScore(ScoreOnHit * player.ScoreMultiplier);
        scoreToDisplay = (ScoreOnHit * player.ScoreMultiplier).ToString();
        getScoreToDisplay = false;
        secondsBeforeRemovalTimer = secondsBeforeRemoval;
        showScore = true;
        scoreDisplayTimer = ScoreDisplayDurationSeconds;
    }

    protected bool CheckBallCollision(Ball ball)
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
        Vector2 halfSize = new Vector2(Width / 2f, Height / 2f);

        Vector2 localBallPos = rotatedBallPos - Position;
        
        float closestX = MathHelper.Clamp(localBallPos.X, -halfSize.X, halfSize.X);
        float closestY = MathHelper.Clamp(localBallPos.Y, -halfSize.Y, halfSize.Y);

        Vector2 closestPoint = new Vector2(closestX, closestY);
        Vector2 normal = localBallPos - closestPoint;

        if (normal.LengthSquared() < 0.0001f) //This is to prevent ball from disappearing when hitting a corner
        {
            float leftDist = MathF.Abs(localBallPos.X + halfSize.X);
            float rightDist = MathF.Abs(localBallPos.X - halfSize.X);
            float topDist = MathF.Abs(localBallPos.Y + halfSize.Y);
            float bottomDist = MathF.Abs(localBallPos.Y - halfSize.Y);

            float minDist = MathF.Min(MathF.Min(leftDist, rightDist), MathF.Min(topDist, bottomDist));

            if (minDist == leftDist) normal = new Vector2(-1, 0);
            else if (minDist == rightDist) normal = new Vector2(1, 0);
            else if (minDist == topDist) normal = new Vector2(0, -1);
            else normal = new Vector2(0, 1);
        }
        else
        {
            normal = Vector2.Normalize(normal);
        }

        return RotateVector(normal, Rotation);
    }

    protected void ResolveBallCollision(Ball ball)
    {
        Vector2 normal = CalculateCollisionNormal(ball);
        ballManager.AddCollisionNormal(ball, normal);
        
        Vector2 finalNormal = ballManager.GetAveragedNormal(ball);
        if (finalNormal == Vector2.Zero) finalNormal = normal;
        
        Vector2 tangent = new Vector2(-finalNormal.Y, finalNormal.X);
        float normalVelocity = Vector2.Dot(ball.Velocity, finalNormal);
        float tangentVelocity = Vector2.Dot(ball.Velocity, tangent);
        float newNormalVelocity = -normalVelocity * ball.Restitution;

        Vector2 newVelocity = (finalNormal * newNormalVelocity) + (tangent * tangentVelocity);
        
        if (!float.IsNaN(newVelocity.X) && !float.IsNaN(newVelocity.Y))
        {
            ball.Velocity = newVelocity;
            ball.Direction = Vector2.Normalize(ball.Velocity);
        }

        Vector2 closestPoint = GetClosestPointOnBrick(ball);
        float overlap = ball.Origin.X - Vector2.Distance(ball.Position, closestPoint);
        
        if (overlap > 0 && !float.IsNaN(finalNormal.X) && !float.IsNaN(finalNormal.Y))
        {
            Vector2 adjustment = finalNormal * overlap;
            if (!float.IsNaN(adjustment.X) && !float.IsNaN(adjustment.Y))
            {
                ball.Position += adjustment;
            }
        }
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
    public void ScoreUpdate()
    {
        if (Hit)
        {
            if (getScoreToDisplay)
            {
                int scoreMultiplied = ScoreOnHit * player.ScoreMultiplier;
                scoreToDisplay = scoreMultiplied.ToString();
                getScoreToDisplay = false;
            }

            secondsBeforeRemovalTimer -= Globals.TotalSeconds;

            if (secondsBeforeRemovalTimer <= 0 || ballManager.balls.Count <= 0)
            {
                IsMarkedForRemoval = true;
                return;
            }

            if (showScore)
            {
                scoreDisplayTimer -= Globals.TotalSeconds;
                if (scoreDisplayTimer <= 0)
                {
                    showScore = false;
                    hasShownScore = true;
                }
            }
        }

        TextureCurrent = Hit ? TextureHit : TextureNotHit;
    }

    public virtual void Update()
    {
        CheckCollisions();
        ScoreUpdate();
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

            Vector2 pos = Position + new Vector2(0, TextureHit.Height / 2);
            Vector2 textOrigin = new Vector2(Globals.ScoreOnHitFont.MeasureString(scoreToDisplay).X / 2, 0);
            Globals.SpriteBatch.DrawString(Globals.ScoreOnHitFont, scoreToDisplay, pos, Color.White, 0f, textOrigin, 1f, SpriteEffects.None, 0f);
        }
    }
}