namespace Slutprojekt;
public class UI
{
    public Player player;
    public void Init(Player plyr)
    {
        player = plyr;
    }
    public void Draw()
    {
        Vector2 scorePos = new(Globals.Bounds.X-200, 25);
        Globals.SpriteBatch.DrawString(Globals.Font, player.Score.ToString(), scorePos, Color.White);

        Vector2 scoreMultPos = new(Globals.Bounds.X-200, 75);
        Globals.SpriteBatch.DrawString(Globals.Font, player.ScoreMultiplier.ToString(), scoreMultPos, Color.White);
    }
}