namespace Slutprojekt;
public class ExplodePowerup : BasePowerup
{
    private readonly LevelCombiner levelCombiner;
    private float explosionRadius = 100f;

    public ExplodePowerup(BallManager ballManager, LevelCombiner levelCombiner) : base(ballManager)
    {
        this.levelCombiner = levelCombiner;
    }

    public override string Description()
    {
        string description = "";
        return description;
    }

    public override void PowerupAbility(Ball ball)
    {

        Vector2 explosionCenter = ball.Position;

        foreach (var grid in levelCombiner.levelGrids)
        {
            foreach (var circle in grid.circlePlacer.GetCircles())
            {
                if (!circle.Hit && !circle.IsMarkedForRemoval)
                {
                    float dist = Vector2.Distance(explosionCenter, circle.Position + circle.Origin);
                    if (dist <= explosionRadius)
                    {
                        circle.SetHit();
                        ball.HasHit();
                    }
                }
            }

            foreach (var brick in grid.brickPlacer.GetBricks())
            {
                if (!brick.Hit && !brick.IsMarkedForRemoval)
                {
                    float dist = Vector2.Distance(explosionCenter, brick.Position);
                    if (dist <= explosionRadius)
                    {
                        brick.SetHit();
                        ball.HasHit();
                    }
                }
            }
        }
    }
}