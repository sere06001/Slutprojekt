namespace Slutprojekt;
public class BallManager
{
    public readonly List<Ball> balls = [];

    public BallManager()
    {
        for (int i = 0; i < 10; i++)
        {
            balls.Add(new());
        }
    }

    private void CheckCollisions()
    {
        // Ball-to-ball collisions only
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
    public void SpawnBall(Vector2 position)
    {
        Ball newBall = new Ball
        {
            Position = position,
            Velocity = Vector2.Zero,
        };
        balls.Add(newBall);
    }

    public void Update()
    {
        foreach (var ball in balls)
        {
            ball.Update();
        }
        CheckCollisions();
    }

    public void Draw()
    {
        foreach (var ball in balls)
        {
            ball.Draw();
        }
    }
}