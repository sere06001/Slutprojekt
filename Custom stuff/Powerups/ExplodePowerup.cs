namespace Slutprojekt;
public class ExplodePowerup : BasePowerup
{
    private readonly LevelCombiner levelCombiner;
    private float explosionRadius = 100f;
    private List<Vector2> processedExplosions = new();

    public ExplodePowerup(BallManager ballManager, LevelCombiner levelCombiner) : base(ballManager)
    {
        this.levelCombiner = levelCombiner;
    }

    public override string Description()
    {
        string description = $"Explodes all bricks and \ncircles within a {explosionRadius} pixel \nradius of the ball.";
        return description;
    }

    private void TriggerExplosion(Vector2 center, Ball ball)
    {
        if (processedExplosions.Contains(center)) return;
        processedExplosions.Add(center);

        foreach (var grid in levelCombiner.levels)
        {
            foreach (var circle in grid.circlePlacer.GetCircles())
            {
                if (!circle.Hit && !circle.IsMarkedForRemoval)
                {
                    float dist = Vector2.Distance(center, circle.Position + circle.Origin);
                    if (dist <= explosionRadius)
                    {
                        circle.SetHit();
                        ball.HasHit();

                        if (circle is GreenCircle)
                        {
                            TriggerExplosion(circle.Position + circle.Origin, ball);
                        }
                    }
                }
            }

            foreach (var brick in grid.brickPlacer.GetBricks())
            {
                if (!brick.Hit && !brick.IsMarkedForRemoval)
                {
                    float dist = Vector2.Distance(center, brick.Position);
                    if (dist <= explosionRadius)
                    {
                        brick.SetHit();
                        ball.HasHit();

                        if (brick is GreenBrick)
                        {
                            TriggerExplosion(brick.Position, ball);
                        }
                    }
                }
            }
        }
        foreach (var circle in levelCombiner.circlePlacer.GetCircles())
        {
            if (!circle.Hit && !circle.IsMarkedForRemoval)
            {
                float dist = Vector2.Distance(center, circle.Position + circle.Origin);
                if (dist <= explosionRadius)
                {
                    circle.SetHit();
                    ball.HasHit();
                    if (circle is GreenCircle)
                    {
                        TriggerExplosion(circle.Position + circle.Origin, ball);
                    }
                }
            }
        }

        foreach (var brick in levelCombiner.brickPlacer.GetBricks())
        {
            if (!brick.Hit && !brick.IsMarkedForRemoval)
            {
                float dist = Vector2.Distance(center, brick.Position);
                if (dist <= explosionRadius)
                {
                    brick.SetHit();
                    ball.HasHit();
                    if (brick is GreenBrick)
                    {
                        TriggerExplosion(brick.Position, ball);
                    }
                }
            }
        }
    }

    public override void PowerupAbility(Ball ball)
    {
        processedExplosions.Clear();
        TriggerExplosion(ball.Position, ball);
    }
}