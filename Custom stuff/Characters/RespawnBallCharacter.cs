namespace Slutprojekt;
public class RespawnBallCharacter : BaseCharacter
{
    public RespawnBallCharacter(BallManager ballmanager) : base(ballmanager)
    {
        Powerup = new RespawnBallPowerup(ballmanager);
        Name = "Ghost";
    }
    public override string Description()
    {
        return $"{Powerup.Description()}";
    }
}