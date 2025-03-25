namespace Slutprojekt;
public class RedCircle : BaseCircle
{
    public RedCircle(BallManager ballmng) : base(ballmng)
    {
        ScoreOnHit = 100;

        ballManager = ballmng;

        TextureCurrent = Globals.BallRed;
        TextureHit = Globals.BallRedHit;
        TextureNotHit = Globals.BallRed;
    }
}