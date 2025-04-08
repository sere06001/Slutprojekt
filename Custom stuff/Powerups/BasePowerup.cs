namespace Slutprojekt;
public abstract class BasePowerup
{
    public virtual BallManager ballManager { get; set; }
    public virtual bool IsActive { get; private set; } //Set to false if BallManager.balls <= 0
    public virtual bool HasBeenUsed { get; protected set; } = false;
    public BasePowerup(BallManager ballManager)
    {
        this.ballManager = ballManager;
    }
    public abstract string Description();
    public abstract void PowerupAbility(Vector2 ballpos);
    public virtual void ResetPowerup()
    {
        IsActive = false;
    }
}