namespace Slutprojekt;
public class BallManager
{
    public const int startingBallCount = 10;
    public int BallsLeft { get; private set; } = startingBallCount;
    public List<Ball> balls = []; //Currently active balls
    private void DebugUI()
    {
        Vector2 pos = new(200, 25);
        Globals.SpriteBatch.DrawString(Globals.Font, $"Active balls: {balls.Count}", pos, Color.White);
        pos = new(200, 75);
        Globals.SpriteBatch.DrawString(Globals.Font, $"Starting balls: {BallsLeft}", pos, Color.White);
    }
    private void DrawKillZone()
    {
        Rectangle killBox = new Rectangle(
            0,
            (int)Globals.RestrictionCoordsLower,
            Globals.Bounds.X,
            (int)(Globals.Bounds.Y - Globals.RestrictionCoordsLower)
        );
        Color killZoneColor = new Color(Color.Red, 0.3f);
        Globals.SpriteBatch.Draw(Globals.Pixel, killBox, killZoneColor);
    }
    public void AddBall5050()
    {
        if (Globals.Random.Next(2) == 0)
        {
            BallsLeft++;
        }
    }
    private void RemoveBallAtBottom()
    {
        bool hasHitObject;
        bool isDuplicate;
        bool willRespawn;
        bool isLowerThanKillZone;
        foreach (Ball ball in balls)
        {
            hasHitObject = ball.HasHitBrickOrCircle;
            isDuplicate = ball.IsDuplicate;
            willRespawn = ball.WillRespawn;
            isLowerThanKillZone = ball.Position.Y + ball.texture.Height > Globals.RestrictionCoordsLower;
            if (isLowerThanKillZone && willRespawn && hasHitObject)
            {
                ball.SetRespawn(false);
                ball.Position = new Vector2(ball.Position.X, 0);
            }
            else if (!hasHitObject && !isDuplicate && !willRespawn)
            {
                if (isLowerThanKillZone)
                {
                    AddBall5050();
                }
            }
        }
        balls.RemoveAll(ball => ball.Position.Y + ball.texture.Height > Globals.RestrictionCoordsLower);
    }
    private void CheckCollisions()
    {
        for (int i = 0; i < balls.Count - 1; i++)
        {
            for (int j = i + 1; j < balls.Count; j++)
            {
                if ((balls[i].Position - balls[j].Position).Length() < (balls[i].Origin.X + balls[j].Origin.X))
                {
                    ResolveCollision(balls[i], balls[j]);
                }
            }
        }
    }

    private void ResolveCollision(Ball b1, Ball b2)
    {
        Vector2 normal = Vector2.Normalize(b2.Position - b1.Position);
        Vector2 relativeVelocity = b2.Velocity - b1.Velocity;

        float restitution = b1.Restitution;
        float impulseMagnitude = -(1 + restitution) * Vector2.Dot(relativeVelocity, normal) / 2;

        Vector2 impulse = impulseMagnitude * normal;
        b1.Velocity -= impulse;
        b2.Velocity += impulse;

        b1.Direction = Vector2.Normalize(b1.Velocity);
        b2.Direction = Vector2.Normalize(b2.Velocity);

        float overlap = b1.Origin.X + b2.Origin.X - Vector2.Distance(b1.Position, b2.Position);
        Vector2 separation = overlap * 0.5f * normal;
        b1.Position -= separation;
        b2.Position += separation;
    }

    public void ShootBall(Vector2 position, Vector2 direction)
    {
        if (BallsLeft <= 0 || balls.Count > 0) return;

        Ball newBall = new Ball(position, false)
        {
            Direction = direction,
            Velocity = direction * Ball.Speed // Increased initial velocity for cannon shot
        };
        balls.Add(newBall);
        BallsLeft--;
    }

    public void AddBallsLeft()
    {
        BallsLeft++;
    }

    public void Update(Player player)
    {
        RemoveBallAtBottom();
        foreach (Ball ball in balls)
        {
            ball.Update();
        }
        CheckCollisions();
        if (balls.Count == 0)
        {
            player.UpdateFinalScore();
            player.ResetScore();
            player.ResetCircleAndBricksHitCount();
        }
    }

    public void Draw()
    {
        DrawKillZone();
        foreach (Ball ball in balls)
        {
            ball.Draw();
        }
        DebugUI();
    }
}