namespace Slutprojekt;
public class DuplicateBallPowerup : BasePowerup
{
    public DuplicateBallPowerup(BallManager ballmanager) : base(ballmanager)
    {
        ballManager = ballmanager;
    }
    public override string Description()
    {
        string description = "";
        return description;
    }
    public override void PowerupAbility() //Vector2 pos of ball that hit brick
    {
        ballManager.balls.Add(new()); //Add ball at pos with upward velocity
    }
}