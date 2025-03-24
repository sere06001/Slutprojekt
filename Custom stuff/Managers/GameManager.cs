namespace Slutprojekt;
public class GameManager
{
    public BallManager ballManager = new();
    private LevelBase currentLevel;

    public GameManager()
    {
        //currentLevel = new LevelCircle(ballManager, 500f, 50, Globals.Bounds.X/2, Globals.Bounds.Y/2, true); //Just for testing
        currentLevel = new LevelGrid(ballManager, 5, 5, Globals.BrickBlue.Width, Globals.Bounds.X/2, Globals.Bounds.Y/2, true, 45); //Just for testing
    }

    public void Update()
    {
        ballManager.Update();
        currentLevel.Update();
    
        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
        {
            Vector2 mousePosition = Mouse.GetState().Position.ToVector2();
    
            ballManager.SpawnBall(mousePosition);
        }
    }

    public void Draw()
    {
        ballManager.Draw();
        currentLevel.Draw();
    }
}