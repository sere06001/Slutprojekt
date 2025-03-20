namespace Slutprojekt;
public abstract class BasePowerup
{
    protected abstract BasePowerup Powerup { get; set; }
    protected abstract int DurationInBounces { get; set; }
    protected abstract void Description();
}