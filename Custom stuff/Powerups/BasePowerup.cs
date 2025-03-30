namespace Slutprojekt;
public abstract class BasePowerup
{
    protected virtual bool IsActive { get; set; } //Set to false if BallManager.balls <= 0
    public abstract string Description();
}