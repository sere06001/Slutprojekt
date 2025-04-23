namespace Slutprojekt;
public class BreakRedsCharacter : BaseCharacter
{
    public BreakRedsCharacter(BallManager ballmanager, LevelCombiner levelCombiner) : base(ballmanager)
    {
        Powerup = new BreakRedsPowerup(ballmanager, levelCombiner);
        Name = "Sunflower";
    }
    public override string Description()
    {
        return $"{Powerup.Description()}";
    }
}