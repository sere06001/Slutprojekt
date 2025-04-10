namespace Slutprojekt;
public class DuplicateBallPowerup : BasePowerup
{
    public DuplicateBallPowerup(BallManager ballmanager) : base(ballmanager)
    {
        
    }
    public override string Description()
    {
        string description = "";
        return description;
    }
    public override void PowerupAbility(Ball ball) //Vector2 pos of ball that hit circle
    {
        Vector2 ballPos = new(ball.Position.X, ball.Position.Y-10); //Create new ball at pos
        ballManager.balls.Add(new Ball(ballPos)); //Add ball at pos with upward velocity
    }
}