namespace Slutprojekt;
public class BreakRedsPowerup : BasePowerup
{
    public BreakRedsPowerup(BallManager ballmanager) : base(ballmanager)
    {
        
    }
    public override string Description()
    {
        string description = "";
        return description;
    }
    public override void PowerupAbility(Ball ball)
    {
        Vector2 ballPos = new(ball.Position.X, ball.Position.Y);
        ballManager.balls.Add(new Ball(ballPos));
    }
}