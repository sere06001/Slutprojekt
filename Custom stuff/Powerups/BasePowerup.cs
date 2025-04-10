namespace Slutprojekt;
public abstract class BasePowerup
{
    public virtual BallManager ballManager { get; set; }
    public virtual bool IsActive { get; private set; } //Set to false if BallManager.balls <= 0
    public virtual bool HasBeenUsed { get; protected set; } = false;
    public virtual int TurnDurationStart { get; protected set; } = 0;
    public virtual int TurnDuration { get; protected set; }
    public BasePowerup(BallManager ballManager)
    {
        this.ballManager = ballManager;
        TurnDuration = TurnDurationStart;
    }
    public virtual void DecreaseTurnsLeft()
    {
        TurnDuration--;
    }
    public abstract string Description();
    public abstract void PowerupAbility(Ball ball);
    public virtual void ResetPowerup()
    {
        IsActive = false;
    }
}