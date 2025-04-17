namespace Slutprojekt;
public class BreakRedsPowerup : BasePowerup
{
    private LevelCombiner levelCombiner;
    private int percentOfTotalRedsToBreak = 20;
    public BreakRedsPowerup(BallManager ballManager, LevelCombiner levelCombiner) : base(ballManager)
    {
        this.levelCombiner = levelCombiner;
    }

    public override string Description()
    {
        int denominator = 100/percentOfTotalRedsToBreak;
        string description = $"Breaks 1/{denominator} of all active red bricks and circles rounded up.";
        return description;
    }

    public override void PowerupAbility(Ball ball)
    {
        var redObjects = new List<(float distance, object obj)>();

        foreach (var grid in levelCombiner.levels)
        {

            var circles = grid.circlePlacer.GetCircles();
            var bricks = grid.brickPlacer.GetBricks();
            
            foreach (var circle in circles.Where(c => c is RedCircle && !c.Hit && !c.IsMarkedForRemoval))
            {
                float dist = Vector2.Distance(ball.Position, circle.Position);
                redObjects.Add((dist, circle));
            }

            foreach (var brick in bricks.Where(b => b is RedBrick && !b.Hit && !b.IsMarkedForRemoval))
            {
                float dist = Vector2.Distance(ball.Position, brick.Position);
                redObjects.Add((dist, brick));
            }
        }

        //Round up instead of down
        int objectsToBreak = (int)Math.Ceiling(redObjects.Count * (percentOfTotalRedsToBreak / 100f));
        if (objectsToBreak == 0 && redObjects.Count > 0)
        {
            objectsToBreak = 1;
        }

        //Break closest reds
        redObjects.Sort((a, b) => a.distance.CompareTo(b.distance));
        
        for (int i = 0; i < objectsToBreak; i++)
        {
            switch (redObjects[i].obj)
            {
                case RedCircle circle:
                    circle.SetHit();
                    break;
                case RedBrick brick:
                    brick.SetHit();
                    break;
            }
            ball.HasHit();
        }
    }
}