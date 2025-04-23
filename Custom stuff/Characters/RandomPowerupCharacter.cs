namespace Slutprojekt;
public class RandomPowerupCharacter : BaseCharacter
{
    private LevelCombiner levelCombiner;

    public RandomPowerupCharacter(BallManager ballmanager, LevelCombiner levelCombiner) : base(ballmanager)
    {
        this.levelCombiner = levelCombiner;
        Powerup = new ExplodePowerup(ballmanager, levelCombiner);
        Name = "Shark";
    }

    public override string Description()
    {
        return $"Gets a new random \npowerup on hit.";
    }

    public override BasePowerup SetRandomPowerup(Ball ball)
    {
        List<BasePowerup> powerups = new List<BasePowerup>
        {
            new FireballPowerup(ballManager),
            new RespawnBallPowerup(ballManager),
            new ExplodePowerup(ballManager, levelCombiner),
            new BreakRedsPowerup(ballManager, levelCombiner),
            new DuplicateBallPowerup(ballManager)
        };
        int randomPowerup = Globals.Random.Next(0, powerups.Count);
        Powerup = powerups[randomPowerup];
        return Powerup;
    }
}