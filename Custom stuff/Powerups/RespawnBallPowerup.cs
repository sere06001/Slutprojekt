namespace Slutprojekt;
public class RespawnBallPowerup : BasePowerup
{
    public RespawnBallPowerup(BallManager ballmanager) : base(ballmanager)
    {
        
    }
    public override string Description()
    {
        string description = "Respawns a ball at the \ntop when it has fallen \nout of the map.";
        return description;
    }
    public override void PowerupAbility(Ball ball) //Make ball respawn if hit killzone
    {
        ball.SetRespawn(true);
    }
}