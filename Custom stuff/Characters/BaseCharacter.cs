namespace Slutprojekt;
public abstract class BaseCharacter
{
    protected virtual BasePowerup Powerup { get; set; }
    protected virtual Texture texture { get; set; }
    protected virtual Vector2 Position { get; set; }
    public virtual void Draw()
    {

    }
}
