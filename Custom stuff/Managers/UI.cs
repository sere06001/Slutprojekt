namespace Slutprojekt;
public class UI
{
    public Player player;
    public BallManager ballManager;
    public void Init(Player plyr)
    {
        player = plyr;
        ballManager = player.ballManager;
    }
    public void DebugUI()
    {
        Vector2 scorePos = new(Globals.Bounds.X-400, 0);
        Globals.SpriteBatch.DrawString(Globals.Font, "Score from hits: "+player.ScoreFromHits.ToString(), scorePos, Color.White);

        Vector2 FinalscorePos = new(Globals.Bounds.X-400, 25);
        Globals.SpriteBatch.DrawString(Globals.Font, "Score level: "+player.ScoreLevel.ToString(), FinalscorePos, Color.White);

        
    }
    public void DrawLevelScore(int level)
    {
        int highScore = ScoreManager.GetHighScore(level);
        Vector2 pos = new(Globals.LeftWall+10, 10);
        Globals.SpriteBatch.DrawString(Globals.Font, $"High Score: {highScore}", pos, Color.White);

        string levelscoreText = $"Score: {player.ScoreFromHits}";
        Vector2 scoreLevelPos = new(Globals.RightWall-Globals.Font.MeasureString(levelscoreText).X-5, 10);
        Globals.SpriteBatch.DrawString(Globals.Font, levelscoreText, scoreLevelPos, Color.White);

        string scoreText = $"Score multiplier: "+player.ScoreMultiplier.ToString();
        Vector2 scoreMultPos = new(Globals.RightWall-Globals.Font.MeasureString(scoreText).X-5, 50);
        Globals.SpriteBatch.DrawString(Globals.Font, scoreText, scoreMultPos, Color.White);

        string redHitsText = $"Red hits: {player.RedsHit}/{Globals.maxRedObjects}";
        Vector2 redHits = new(Globals.RightWall-Globals.Font.MeasureString(redHitsText).X-5, 90);
        Globals.SpriteBatch.DrawString(Globals.Font, redHitsText, redHits, Color.White);
    }
    public void DrawBallCount()
    {
        Vector2 pos = new(Globals.LeftWall+10, 50);
        Globals.SpriteBatch.DrawString(Globals.Font, $"Balls left: {ballManager.BallsLeft}", pos, Color.White);
    }
    public void Draw()
    {
        //DebugUI();
        DrawLevelScore(player.currentLevel);
        DrawBallCount();
    }
}