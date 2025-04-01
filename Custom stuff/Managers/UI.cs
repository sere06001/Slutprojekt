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
        Vector2 scorePos = new(Globals.Bounds.X-200, 0+150);
        Globals.SpriteBatch.DrawString(Globals.Font, player.Score.ToString(), scorePos, Color.White);
    }
}