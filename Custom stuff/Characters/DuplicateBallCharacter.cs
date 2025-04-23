namespace Slutprojekt;
public class DuplicateBallCharacter : BaseCharacter
{
    public DuplicateBallCharacter(BallManager ballmanager) : base(ballmanager)
    {
        Powerup = new DuplicateBallPowerup(ballmanager);
        Name = "Bunny";
    }
    public override string Description()
    {
        return $"{Powerup.Description()}";
    }
}