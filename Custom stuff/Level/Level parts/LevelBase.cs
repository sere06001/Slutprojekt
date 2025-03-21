namespace Slutprojekt;
public abstract class LevelBase
{
    protected Texture2D ballRed = Globals.Content.Load<Texture2D>("ballred.png");
    protected Texture2D ballRedHit = Globals.Content.Load<Texture2D>("ballredhit.png");
    protected Texture2D ballBlue = Globals.Content.Load<Texture2D>("ballblue.png");
    protected Texture2D ballBlueHit = Globals.Content.Load<Texture2D>("ballbluehit.png");
    protected Texture2D ballGreen = Globals.Content.Load<Texture2D>("ballgreen.png");
    protected Texture2D ballGreenHit = Globals.Content.Load<Texture2D>("ballgreenhit.png");
    protected Texture2D ballPurple = Globals.Content.Load<Texture2D>("ballpurple.png");
    protected Texture2D ballPurpleHit = Globals.Content.Load<Texture2D>("ballpurplehit.png");
    protected virtual Vector2 Position { get; set; }
    public abstract void Draw();
}