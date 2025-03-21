namespace Slutprojekt;
public static class Globals
{
    public static Texture2D BallRed { get; } = Globals.Content.Load<Texture2D>("ballred.png");
    public static Texture2D BallRedHit { get; } = Globals.Content.Load<Texture2D>("ballredhit.png");
    public static Texture2D BallBlue { get; } = Globals.Content.Load<Texture2D>("ballblue.png");
    public static Texture2D BallBlueHit { get; } = Globals.Content.Load<Texture2D>("ballbluehit.png");
    public static Texture2D BallGreen { get; } = Globals.Content.Load<Texture2D>("ballgreen.png");
    public static Texture2D BallGreenHit { get; } =Globals.Content.Load<Texture2D>("ballgreenhit.png");
    public static Texture2D BallPurple { get; } = Globals.Content.Load<Texture2D>("ballpurple.png");
    public static Texture2D BallPurpleHit { get; } = Globals.Content.Load<Texture2D>("ballpurplehit.png");
    public static float TotalSeconds { get; set; }
    public static ContentManager Content { get; set; }
    public static SpriteBatch SpriteBatch { get; set; }
    public static Point Bounds { get; set; }

    public static void Update(GameTime gt)
    {
        TotalSeconds = (float)gt.ElapsedGameTime.TotalSeconds;
    }
}