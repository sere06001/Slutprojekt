namespace Slutprojekt;
public class UI
{
    public Player player;
    public void Init(Player plyr)
    {
        player = plyr;
    }
    public void DebugUI()
    {
        Vector2 scorePos = new(Globals.Bounds.X-200, 0);
        Globals.SpriteBatch.DrawString(Globals.Font, player.Score.ToString(), scorePos, Color.White);

        Vector2 FinalscorePos = new(Globals.Bounds.X-200, 25);
        Globals.SpriteBatch.DrawString(Globals.Font, player.FinalScore.ToString(), FinalscorePos, Color.White);

        Vector2 scoreMultPos = new(Globals.Bounds.X-200, 75);
        Globals.SpriteBatch.DrawString(Globals.Font, player.ScoreMultiplier.ToString(), scoreMultPos, Color.White);
    }
    public void Draw()
    {
        DebugUI();
    }
}