namespace Slutprojekt;
public class Teleporter
{
    private Vector2 teleporter1Pos;
    private Vector2 teleporter2Pos;
    private float teleportRadius = 25f;
    private Texture2D teleporterTexture = Globals.BallTexture; //temporary
    private HashSet<Ball> teleportedBalls = new();

    public Teleporter(Vector2 teleporter1Pos, Vector2 teleporter2Pos)
    {
        this.teleporter1Pos = teleporter1Pos;
        this.teleporter2Pos = teleporter2Pos;
    }

    public void TeleportBall(Ball ball)
    {
        float distToTele1 = Vector2.Distance(ball.Position, teleporter1Pos);
        float distToTele2 = Vector2.Distance(ball.Position, teleporter2Pos);

        if (distToTele1 >= teleportRadius && distToTele2 >= teleportRadius)
        {
            teleportedBalls.Remove(ball);
        }

        if (!teleportedBalls.Contains(ball))
        {
            if (distToTele1 < teleportRadius)
            {
                ball.Position = teleporter2Pos;
                teleportedBalls.Add(ball);
            }
            else if (distToTele2 < teleportRadius)
            {
                ball.Position = teleporter1Pos;
                teleportedBalls.Add(ball);
            }
        }
    }

    public void Update(Ball ball)
    {
        TeleportBall(ball);
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(teleporterTexture, teleporter1Pos, null, Color.White, 0f, new Vector2(teleporterTexture.Width / 2, teleporterTexture.Height / 2), 1f, SpriteEffects.None, 0f);
        Globals.SpriteBatch.Draw(teleporterTexture, teleporter2Pos, null, Color.White, 0f, new Vector2(teleporterTexture.Width / 2, teleporterTexture.Height / 2), 1f, SpriteEffects.None, 0f);
    }
}