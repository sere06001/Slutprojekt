namespace Slutprojekt;
public class DuplicateBallPowerup : BasePowerup
{
    public override string Description()
    {
        string description = "";
        return description;
    }
    public override void UsePowerup()
    {
        ballManager.balls.Add(new());
    }
}