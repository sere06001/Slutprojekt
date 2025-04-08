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
        Vector2 scorePos = new(Globals.Bounds.X-400, 0);
        Globals.SpriteBatch.DrawString(Globals.Font, "Score from hits: "+player.ScoreFromHits.ToString(), scorePos, Color.White);

        Vector2 FinalscorePos = new(Globals.Bounds.X-400, 25);
        Globals.SpriteBatch.DrawString(Globals.Font, "Score level: "+player.ScoreLevel.ToString(), FinalscorePos, Color.White);

        Vector2 scoreMultPos = new(Globals.Bounds.X-400, 50);
        Globals.SpriteBatch.DrawString(Globals.Font, "Score mult: "+player.ScoreMultiplier.ToString(), scoreMultPos, Color.White);

        Vector2 redHits = new(Globals.Bounds.X-400, 75);
        Globals.SpriteBatch.DrawString(Globals.Font, "RedHits: "+player.RedsHit.ToString(), redHits, Color.White);
    }
    public void Draw()
    {
        DebugUI();
    }
}