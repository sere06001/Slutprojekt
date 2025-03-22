
namespace Slutprojekt;
public class BlueBrick : BaseBrick
{
    public BlueBrick(BallManager ballmng, float rotation) : base(ballmng, rotation)
    {
        ScoreOnHit = 200;

        ballManager = ballmng;

        TextureCurrent = Globals.BrickBlue;
        TextureHit = Globals.BrickBlueHit;
        TextureNotHit = Globals.BrickBlue;
    }
}