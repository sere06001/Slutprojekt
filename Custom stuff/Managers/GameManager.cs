namespace Slutprojekt;
public class GameManager
{
    public BallManager ballManager = new();
    private LevelBase currentLevel;
    private MouseState previousMouseState;

    public GameManager()
    {
        //Change to LevelGenerator.Update() later, currentLevel is just for testing purposes

        //currentLevel = new LevelCircle(ballManager, 100f, 10, Globals.Bounds.X/2, Globals.Bounds.Y/2, false); //Just for testing
        currentLevel = new LevelGrid(ballManager, 5, 5, Globals.BrickBlue.Width, Globals.Bounds.X/2, Globals.Bounds.Y/2, true, 0); //Just for testing
    }

    public void Update()
    {
        ballManager.Update();
        currentLevel.Update(); //Also for testing, change to LevelGenerator.Update() which will handle the main level system to keep GameManager clean
    
        MouseState currentMouseState = Mouse.GetState();
        
        if (currentMouseState.LeftButton == ButtonState.Pressed && //Spawns 1 ball on click
            previousMouseState.LeftButton == ButtonState.Released)
        {
            Vector2 mousePosition = currentMouseState.Position.ToVector2();
            ballManager.SpawnBall(mousePosition);
        }

        previousMouseState = currentMouseState;
    }

    public void Draw()
    {
        ballManager.Draw();
        currentLevel.Draw();
    }
}