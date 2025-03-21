namespace Slutprojekt;
public class GreenCircle : BaseCircle
{
    public GreenCircle(BallManager ballmng) : base(ballmng)
    {
        ScoreOnHit = 500;

        ballManager = ballmng;

        TextureCurrent = Globals.BallGreen;
        TextureHit = Globals.BallGreenHit;
        TextureNotHit = Globals.BallGreen;
    }
}