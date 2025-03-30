namespace Slutprojekt;
public abstract class BasePowerup
{
    public virtual bool IsActive { get; set; } //Set to false if BallManager.balls <= 0
    public abstract string Description();
    public virtual void Update()
    {

    }
}