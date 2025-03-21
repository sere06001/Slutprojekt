namespace Slutprojekt;
public abstract class LevelSnake : LevelBase
{
    protected override Vector2 Position { get; set; }
    public void SnakePlacer()
    {
        
    }
    public override void Draw()
    {
        Globals.SpriteBatch.Draw(ballRed, Position, Color.White);
    }
}