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
    public override void PowerupAbility(Ball ball) //Vector2 pos of ball that hit brick
    {
        Vector2 ballPos = new(ball.Position.X, ball.Position.Y); //Create new ball at pos
        ballManager.balls.Add(new Ball(ballPos)); //Add ball at pos with upward velocity
    }
}