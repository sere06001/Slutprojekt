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
    public override void PowerupAbility(Vector2 ballpos) //Vector2 pos of ball that hit brick
    {
        Ball ball = new(ballpos, true); //Create new ball at pos
        ballManager.balls.Add(ball); //Add ball at pos with upward velocity
    }
}