namespace Slutprojekt;
public class ExplodeCharacter : BaseCharacter
{
    public ExplodeCharacter(BallManager ballmanager, LevelCombiner levelCombiner) : base(ballmanager)
    {
        Powerup = new ExplodePowerup(ballmanager, levelCombiner);
        Name = "Beaver";
    }
    public override string Description()
    {
        return $"{Powerup.Description()}";
    }
}