namespace Slutprojekt;
public class RedBrick : BaseBrick
{
    protected bool hasAddedRed = false;
    public RedBrick(BallManager ballmng, Player player, float rotation) : base(ballmng, player, rotation)
    {
        ScoreOnHit = 100;

        ballManager = ballmng;

        TextureCurrent = Globals.BrickRed;
        TextureHit = Globals.BrickRedHit;
        TextureNotHit = Globals.BrickRed;
    }
    public override void Update()
    {
        base.Update();
        if (Hit)
        {
            if (!hasAddedRed)
            {
                player.AddRedsHit();
                hasAddedRed = true;
            }
        }
    }
}