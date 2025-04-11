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
        string description = "";
        return description;
    }

    public override void PowerupAbility(Ball ball)
    {
        var redObjects = new List<(float distance, object obj)>();

        foreach (var grid in levelCombiner.levelGrids)
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

        int convertPercent = 100/percentOfTotalRedsToBreak;
        int objectsToBreak = redObjects.Count / convertPercent;
        if (objectsToBreak == 0 && redObjects.Count > 0)
            objectsToBreak = 1;

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