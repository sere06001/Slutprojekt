using System.ComponentModel;

namespace Slutprojekt;
public abstract class BaseCharacter
{
    protected virtual BasePowerup Powerup { get; set; }
    protected virtual Texture Texture { get; set; }
    protected virtual Vector2 Position { get; set; }
    public abstract string Description();
    public virtual void Draw()
    {

    }
}
