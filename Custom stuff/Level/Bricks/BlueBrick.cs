
namespace Slutprojekt;
public class BlueBrick : BaseBrick
{
    public BlueBrick(BallManager ballmng, Player player, float rotation) : base(ballmng, player, rotation)
    {
        ScoreOnHit = 200;

        ballManager = ballmng;

        TextureCurrent = Globals.BrickBlue;
        TextureHit = Globals.BrickBlueHit;
        TextureNotHit = Globals.BrickBlue;
    }
}