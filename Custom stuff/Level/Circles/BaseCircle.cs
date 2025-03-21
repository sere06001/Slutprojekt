namespace Slutprojekt;
public abstract class BaseCircle
{
        protected Texture2D BallRed { get; } = Globals.Content.Load<Texture2D>("ballred.png");
    protected Texture2D BallRedHit { get; } = Globals.Content.Load<Texture2D>("ballredhit.png");
    protected Texture2D BallBlue { get; } = Globals.Content.Load<Texture2D>("ballblue.png");
    protected Texture2D BallBlueHit { get; } = Globals.Content.Load<Texture2D>("ballbluehit.png");
    protected Texture2D BallGreen { get; } = Globals.Content.Load<Texture2D>("ballgreen.png");
    protected Texture2D BallGreenHit { get; } =Globals.Content.Load<Texture2D>("ballgreenhit.png");
    protected Texture2D BallPurple { get; } = Globals.Content.Load<Texture2D>("ballpurple.png");
    protected Texture2D BallPurpleHit { get; } = Globals.Content.Load<Texture2D>("ballpurplehit.png");
    protected Texture2D TextureCurrent { get; set; }
    protected Texture2D TextureHit { get; set; }
    protected Texture2D TextureNotHit { get; set; }
    protected bool Hit { get; set; }
    protected virtual Vector2 Position { get; set; }
    protected BallManager ballManager { get; set; }
    public BaseCircle(BallManager ballmngr)
    {
        ballManager = ballmngr;
    }
    public void CheckHit()
    {
        foreach (Ball ball in ballManager.balls)
        {
            if (ball.Position == Position)
            {
                Hit = true;
                break;
            }
            else
            {
                Hit = false;
            }
        }
    }
    public void Update()
    {
        CheckHit();
        if (Hit)
        {
            TextureCurrent = TextureHit;
        }
        else
        {
            TextureCurrent = TextureNotHit;
        }
    }
    public abstract void Draw();
}