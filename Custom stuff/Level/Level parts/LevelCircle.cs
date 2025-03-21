namespace Slutprojekt;
public abstract class LevelCircle : LevelBase
{
    protected override Vector2 Position { get; set; }
    public override void Draw()
    {
        Globals.SpriteBatch.Draw(ballRed, Position, Color.White);
    }
}