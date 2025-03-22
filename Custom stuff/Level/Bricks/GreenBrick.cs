
namespace Slutprojekt;
public class GreenBrick : BaseBrick
{
    public GreenBrick(BallManager ballmng) : base(ballmng)
    {
        ScoreOnHit = 500;

        ballManager = ballmng;

        TextureCurrent = Globals.BrickGreen;
        TextureHit = Globals.BrickGreenHit;
        TextureNotHit = Globals.BrickGreen;
    }
}