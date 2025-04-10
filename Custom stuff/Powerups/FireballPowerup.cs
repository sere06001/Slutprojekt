namespace Slutprojekt;
public class FireballPowerup : BasePowerup
{
    public FireballPowerup(BallManager ballmanager) : base(ballmanager)
    {
        
    }
    public override string Description()
    {
        string description = "";
        return description;
    }
    public override void PowerupAbility(Ball ball)
    {
        ball.SetFireStatus(true);
    }
}