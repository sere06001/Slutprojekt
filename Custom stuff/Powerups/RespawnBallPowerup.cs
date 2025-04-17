namespace Slutprojekt;
public class RespawnBallPowerup : BasePowerup
{
    public RespawnBallPowerup(BallManager ballmanager) : base(ballmanager)
    {
        
    }
    public override string Description()
    {
        string description = "Respawns a ball when it has fallen out of the map";
        return description;
    }
    public override void PowerupAbility(Ball ball) //Make ball respawn if hit killzone
    {
        ball.SetRespawn(true);
    }
}