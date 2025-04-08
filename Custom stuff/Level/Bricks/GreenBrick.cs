namespace Slutprojekt;
public class GreenBrick : BaseBrick
{
    public GreenBrick(BallManager ballmng, Player player, float rotation) : base(ballmng, player, rotation)
    {
        ScoreOnHit = 10;

        ballManager = ballmng;

        TextureCurrent = Globals.BrickGreen;
        TextureHit = Globals.BrickGreenHit;
        TextureNotHit = Globals.BrickGreen;
    }
    public override void Update()
    {
        base.Update();
        if (Hit)
        {
            if (!hasContributedToPowerup)
            {
               player.Powerup.PowerupAbility();
               hasContributedToPowerup = true;
            }
        }
    }
}