namespace Slutprojekt;
public static class Globals
{
    public static Texture2D BallRed { get; private set; }
    public static Texture2D BallRedHit { get; private set; }
    public static Texture2D BallBlue { get; private set; }
    public static Texture2D BallBlueHit { get; private set; }
    public static Texture2D BallGreen { get; private set; }
    public static Texture2D BallGreenHit { get; private set; }
    public static Texture2D BallPurple { get; private set; }
    public static Texture2D BallPurpleHit { get; private set; }
    
    public static float TotalSeconds { get; set; }
    public static ContentManager Content { get; set; }
    public static SpriteBatch SpriteBatch { get; set; }
    public static Point Bounds { get; set; }

    public static void LoadContent()
    {
        BallRed = Content.Load<Texture2D>("ballred");
        BallRedHit = Content.Load<Texture2D>("ballredhit");
        BallBlue = Content.Load<Texture2D>("ballblue");
        BallBlueHit = Content.Load<Texture2D>("ballbluehit");
        BallGreen = Content.Load<Texture2D>("ballgreen");
        BallGreenHit = Content.Load<Texture2D>("ballgreenhit");
        BallPurple = Content.Load<Texture2D>("ballpurple");
        BallPurpleHit = Content.Load<Texture2D>("ballpurplehit");
    }

    public static void Update(GameTime gt)
    {
        TotalSeconds = (float)gt.ElapsedGameTime.TotalSeconds;
    }
}