namespace Slutprojekt;
public static class Globals
{
    public const int upperBoundForBricksNCircles = 101;
    public const int chanceForRed = 30;
    public const int chanceForPurple = 31;
    public const int chanceForGreen = 41;

    public const int maxReds = 25;
    public const int maxGreenObjects = 2;
    public const int maxPurpleObjects = 3;

    public static Texture2D BallRed { get; private set; }
    public static Texture2D BallRedHit { get; private set; }
    public static Texture2D BallBlue { get; private set; }
    public static Texture2D BallBlueHit { get; private set; }
    public static Texture2D BallGreen { get; private set; }
    public static Texture2D BallGreenHit { get; private set; }
    public static Texture2D BallPurple { get; private set; }
    public static Texture2D BallPurpleHit { get; private set; }

    public static Texture2D BrickRed { get; private set; }
    public static Texture2D BrickRedHit { get; private set; }
    public static Texture2D BrickBlue { get; private set; }
    public static Texture2D BrickBlueHit { get; private set; }
    public static Texture2D BrickGreen { get; private set; }
    public static Texture2D BrickGreenHit { get; private set; }
    public static Texture2D BrickPurple { get; private set; }
    public static Texture2D BrickPurpleHit { get; private set; }

    public static Texture2D Pixel { get; set; }

    public static Texture2D BallTexture { get; set; }

    public static SpriteFont Font { get; set; }
    public static SpriteFont ScoreOnHitFont { get; set; }
    public static float TotalSeconds { get; set; }
    public static ContentManager Content { get; set; }
    public static SpriteBatch SpriteBatch { get; set; }
    public static Point Bounds { get; set; }
    public static Random Random = new();
    public static float Gravity = 5f * 100;
    public static int LeftWall = 300;
    public static int RightWall = 1000;
    public static float RestrictionCoordsLower;

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

        BrickRed = Content.Load<Texture2D>("brickred");
        BrickRedHit = Content.Load<Texture2D>("brickredhit");
        BrickBlue = Content.Load<Texture2D>("brickblue");
        BrickBlueHit = Content.Load<Texture2D>("brickbluehit");
        BrickGreen = Content.Load<Texture2D>("brickgreen");
        BrickGreenHit = Content.Load<Texture2D>("brickgreenhit");
        BrickPurple = Content.Load<Texture2D>("brickpurple");
        BrickPurpleHit = Content.Load<Texture2D>("brickpurplehit");

        BallTexture = Content.Load<Texture2D>("ball");

        Font = Content.Load<SpriteFont>("font");
        ScoreOnHitFont = Content.Load<SpriteFont>("scoreOnHitFont");
        RestrictionCoordsLower = Bounds.Y - 25;
    }

    public static void Update(GameTime gt)
    {
        TotalSeconds = (float)gt.ElapsedGameTime.TotalSeconds;
    }
}