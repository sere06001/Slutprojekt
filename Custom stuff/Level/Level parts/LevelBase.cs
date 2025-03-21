namespace Slutprojekt;
public abstract class LevelBase
{
    protected virtual Vector2 Position { get; set; }
    public abstract void Draw();
}