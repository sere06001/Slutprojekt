namespace Slutprojekt;
public abstract class BaseCharacter
{
    public virtual BasePowerup Powerup { get; protected set; }
    public virtual BallManager ballManager { get; set; }
    protected virtual Texture Texture { get; set; }
    protected virtual Vector2 Position { get; set; }
    public BaseCharacter(BallManager ballmanager)
    {
        ballManager = ballmanager;
    }
    public abstract string Description();
    public virtual void Draw()
    {

    }
}
