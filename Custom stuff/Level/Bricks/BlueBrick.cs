
namespace Slutprojekt;
public class BlueBrick : BaseBrick
{
    public BlueBrick(BallManager ballmng) : base(ballmng)
    {
        ScoreOnHit = 200;

        ballManager = ballmng;

        TextureCurrent = Globals.BrickBlue;
        TextureHit = Globals.BrickBlueHit;
        TextureNotHit = Globals.BrickBlue;
    }
}