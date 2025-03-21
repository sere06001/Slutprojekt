namespace Slutprojekt;
public abstract class BaseCircle
{
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