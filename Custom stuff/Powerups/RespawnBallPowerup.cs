namespace Slutprojekt;
public class RespawnBallPowerup : BasePowerup
{
    public RespawnBallPowerup(BallManager ballmanager) : base(ballmanager)
    {
        
    }
    public override string Description()
    {
        string description = "";
        return description;
    }
    public override void PowerupAbility(Ball ball) //Make ball respawn if hit killzone
    {
        ball.SetRespawn(true);
    }
}