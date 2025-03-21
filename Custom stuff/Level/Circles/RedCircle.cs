namespace Slutprojekt;
public class RedCircle : BaseCircle
{
    public RedCircle(BallManager ballmng) : base(ballmng)
    {
        ballManager = ballmng;

        TextureCurrent = Globals.BallRed;
        TextureHit = Globals.BallRedHit;
        TextureNotHit = Globals.BallRed;
    }
    public override void Draw()
    {
        Globals.SpriteBatch.Draw(TextureCurrent, Position, Color.White);
    }
}