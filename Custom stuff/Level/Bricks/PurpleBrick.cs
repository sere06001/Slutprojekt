namespace Slutprojekt;
public class PurpleBrick : BaseBrick
{
    public PurpleBrick(BallManager ballmng, Player player, float rotation) : base(ballmng, player, rotation)
    {
        ScoreOnHit = 500;
        //ScoreMultiplier = 2;

        ballManager = ballmng;

        TextureCurrent = Globals.BrickPurple;
        TextureHit = Globals.BrickPurpleHit;
        TextureNotHit = Globals.BrickPurple;
    }
    public override void Update()
    {
        base.Update();
        if (Hit)
        {
            if (!player.HasIncreasedMultFromPurple)
            {
                player.IncreaseScoreMultiplier(ScoreMultiplier);
                player.MultFromPurpleCheck();
            }
        }
    }
}