namespace Slutprojekt;
public class GameManager
{
    public BallManager ballManager = new();
    private LevelBase currentLevel;

    public GameManager()
    {
        currentLevel = new LevelCircle(ballManager, 100f, 16); //Just for testing
    }

    public void Update()
    {
        ballManager.Update();
        currentLevel.Update();
    }

    public void Draw()
    {
        ballManager.Draw();
        currentLevel.Draw();
    }
}