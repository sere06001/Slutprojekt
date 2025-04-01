
namespace Slutprojekt;
public class PurpleBrick : BaseBrick
{
    public PurpleBrick(BallManager ballmng, Player player, float rotation) : base(ballmng, player, rotation)
    {
        ScoreOnHit = 1000;
        ScoreMultiplier = 2;

        ballManager = ballmng;

        TextureCurrent = Globals.BrickPurple;
        TextureHit = Globals.BrickPurpleHit;
        TextureNotHit = Globals.BrickPurple;
    }
}