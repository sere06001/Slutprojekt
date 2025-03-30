namespace Slutprojekt;
public abstract class BasePowerup
{
    public virtual BallManager ballManager { get; set; }
    public virtual BrickPlacer brickPlacer { get; set; }
    public virtual CirclePlacer circlePlacer { get; set; }
    public virtual bool IsActive { get; set; } //Set to false if BallManager.balls <= 0
    public virtual bool HasBeenUsed { get; protected set; } = false;
    public abstract string Description();
    public abstract void UsePowerup();
    public virtual void Update()
    {
        foreach (GreenBrick greenBrick in brickPlacer.GetBricks())
        {
            if (greenBrick.Hit && !HasBeenUsed)
            {
                UsePowerup();
                HasBeenUsed = true;
            }
        }
    }
}