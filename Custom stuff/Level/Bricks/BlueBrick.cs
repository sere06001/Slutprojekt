
namespace Slutprojekt;
public class BlueBrick : BaseBrick
{
    public BlueBrick(BallManager ballmng) : base(ballmng)
    {
        ballManager = ballmng;

        TextureCurrent = Globals.BallBlue;
        TextureHit = Globals.BallBlueHit;
        TextureNotHit = Globals.BallBlue;
    }
}