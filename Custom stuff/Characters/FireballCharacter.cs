namespace Slutprojekt;
public class FireballCharacter : BaseCharacter
{
    public FireballCharacter(BallManager ballmanager) : base(ballmanager)
    {
        Powerup = new FireballPowerup(ballmanager);
        Name = "Dragon";
    }
    public override string Description()
    {
        return $"{Powerup.Description()}";
    }
}