using SharpDX.MediaFoundation;

namespace Slutprojekt;
public abstract class BaseCharacter
{
    //protected abstract Texture2D texture = Globals.Content.Load<Texture2D>("orb-blue"); Add character texture
    protected abstract BasePowerup Powerup { get; set; }
    protected abstract Texture texture { get; set; }
    protected virtual Vector2 Position { get; set; }
    public virtual void Draw()
    {
        //Globals.SpriteBatch.Draw(texture, Position, null); Fixa
    }
}