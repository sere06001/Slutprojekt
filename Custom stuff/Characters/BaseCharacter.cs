namespace Slutprojekt;
public abstract class BaseCharacter
{
    protected abstract BasePowerup Powerup { get; set; }
    protected abstract Texture texture { get; set; }
    protected virtual Vector2 Position { get; set; }
    public abstract void Draw();
}