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
        int direction;
        if (ball.CurrentDirection == Ball.HorizontalDirection.Left) //If ball is going left, randomize direction
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
        Vector2 ballPos = new(ball.Position.X + (direction * Globals.BallTexture.Width / 2), ball.Position.Y + Globals.BallTexture.Height / 2); //Create new ball at pos
        ballManager.balls.Add(new Ball(ballPos)); //Add ball at pos with upward velocity
    }
}