
namespace Slutprojekt;
public class RedBrick : BaseBrick
{
    public RedBrick(BallManager ballmng, Player player, float rotation) : base(ballmng, player, rotation)
    {
        ScoreOnHit = 100;

        ballManager = ballmng;

        TextureCurrent = Globals.BrickRed;
        TextureHit = Globals.BrickRedHit;
        TextureNotHit = Globals.BrickRed;
    }
}