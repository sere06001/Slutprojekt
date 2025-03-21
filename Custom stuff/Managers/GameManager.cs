namespace Slutprojekt;
public class GameManager
{
    public BallManager ballManager = new();
    private LevelBase currentLevel;

    public GameManager()
    {
        currentLevel = new LevelCircle(ballManager, 500f, 50); //Just for testing
    }

    public void Update()
    {
        // Update existing balls and the current level
        ballManager.Update();
        currentLevel.Update();
    
        // Check for left mouse button click
        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
        {
            // Get the mouse position
            Vector2 mousePosition = Mouse.GetState().Position.ToVector2();
    
            // Spawn a new ball at the mouse position
            ballManager.SpawnBall(mousePosition);
        }
    }

    public void Draw()
    {
        ballManager.Draw();
        currentLevel.Draw();
    }
}