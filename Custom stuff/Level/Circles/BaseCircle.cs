namespace Slutprojekt;
public abstract class BaseCircle
{
    public Player player;
    public virtual int ScoreOnHit { get; protected set; }
    public virtual int ScoreMultiplier { get; protected set; } = 1;
    private string scoreToDisplay;
    private bool getScoreToDisplay = true;
    private bool HasIncreasedMult { get; set; }
    private float scoreDisplayTimer = 0f;
    private float ScoreDisplayDurationSeconds = 1.5f;
    private bool showScore = false;
    private bool hasShownScore = false;
    private float secondsBeforeRemovalTimer = 0f;
    private float secondsBeforeRemoval = 10f;
    public float Radius => TextureCurrent.Width / 2;
    protected Texture2D TextureCurrent { get; set; }
    protected Texture2D TextureHit { get; set; }
    protected Texture2D TextureNotHit { get; set; }
    protected bool Hit { get; set; }
    public virtual Vector2 Position { get; set; }
    public virtual float Rotation { get; set; }
    public Vector2 Origin => new Vector2(TextureCurrent.Width / 4, TextureCurrent.Height / 4);
    protected BallManager ballManager { get; set; }

    public bool IsMarkedForRemoval { get; private set; } = false;

    public BaseCircle(BallManager ballmngr, Player plyr)
    {
        ballManager = ballmngr;
        player = plyr;
    }

    public void CheckCollisions()
    {
        foreach (Ball ball in ballManager.balls)
        {
            if ((ball.Position - (Position + Origin)).Length() < (ball.Origin.X + Radius))
            {
                ResolveBallCollision(ball);
                if (!Hit)
                {
                    Hit = true;
                    player.AddScore(ScoreOnHit * player.ScoreMultiplier);
                    secondsBeforeRemovalTimer = secondsBeforeRemoval;
                }
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

        if (!Hit)
        {
            showScore = true;
            scoreDisplayTimer = ScoreDisplayDurationSeconds;
        }
    }

    public void DrawScore()
    {
        if (showScore && scoreDisplayTimer > 0)
        {
            Vector2 pos = Position + Origin + new Vector2(0, -TextureHit.Height * 2);
            Vector2 textOrigin = new Vector2(Globals.ScoreOnHitFont.MeasureString(scoreToDisplay).X / 2, 0);
            Globals.SpriteBatch.DrawString(Globals.ScoreOnHitFont, scoreToDisplay, pos, Color.White, 0f, textOrigin, 1f, SpriteEffects.None, 0f);
        }
    }

    public void Update()
    {
        CheckCollisions();

        if (Hit)
        {
            if (getScoreToDisplay)
            {
                int scoreMultiplied = ScoreOnHit * player.ScoreMultiplier;
                scoreToDisplay = scoreMultiplied.ToString();
                getScoreToDisplay = false;
            }

            if (this is PurpleCircle && !HasIncreasedMult)
            {
                player.IncreaseScoreMultiplier(ScoreMultiplier);
                HasIncreasedMult = true;
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

    public void Draw()
    {
        if (IsMarkedForRemoval)
        {
            return;
        }

        Globals.SpriteBatch.Draw(TextureCurrent, Position, null, Color.White, 0f, Origin, 1f, SpriteEffects.None, 0f);

        if (showScore && !hasShownScore)
        {
            DrawScore();
        }
    }
}