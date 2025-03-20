namespace Slutprojekt;
public class GameManager
{
    private readonly List<Ball> balls = [];

    public GameManager()
    {
        for (int i = 0; i < 10; i++)
        {
            balls.Add(new());
        }
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
                    break;
                }
            }
        }
    }

    private void ResolveCollision(Ball b1, Ball b2)
    {
        var dir = Vector2.Normalize(b1.Position - b2.Position);
        b1.Direction = dir;
        b2.Direction = -dir;
    }

    public void Update()
    {
        foreach (var balls in balls)
        {
            balls.Update();
        }

        CheckCollisions();
    }

    public void Draw()
    {
        foreach (var balls in balls)
        {
            balls.Draw();
        }
    }
}