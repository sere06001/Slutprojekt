namespace Slutprojekt;
public class RedCircle : BaseCircle
{
    protected override Vector2 Position { get; set; }
    public RedCircle(BallManager ballmng) : base(ballmng)
    {
        ballManager = ballmng;
    }
    public override void Draw()
    {
        if (!Hit)
        {
            Globals.SpriteBatch.Draw(ballRed, Position, Color.White);
        }
        else
        {
            Globals.SpriteBatch.Draw(ballRedHit, Position, Color.White);
        }
    }
}