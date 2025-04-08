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
    public override void PowerupAbility()
    {
        ballManager.balls.Add(new());
    }
}