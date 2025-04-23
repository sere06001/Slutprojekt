namespace Slutprojekt;
public class FireballPowerup : BasePowerup
{
    public FireballPowerup(BallManager ballmanager) : base(ballmanager)
    {
        
    }
    public override string Description()
    {
        string description = $"Turns a ball into a fireball \nthat incinerates all bricks \nand circles in it's path.";
        return description;
    }
    public override void PowerupAbility(Ball ball)
    {
        ball.SetFireStatus(true);
    }
}