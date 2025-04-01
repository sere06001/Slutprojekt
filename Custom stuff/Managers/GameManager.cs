namespace Slutprojekt;
public class GameManager
{
    public BallManager ballManager = new();
    public Player player;
    public UI UI;
    private LevelBase currentLevel;
    private MouseState previousMouseState;

    public GameManager()
    {
        //Change to LevelGenerator.Update() later, currentLevel is just for testing purposes

        //currentLevel = new LevelCircle(ballManager, 100f, 10, Globals.Bounds.X/2, Globals.Bounds.Y/2, false); //Just for testing
        currentLevel = new LevelGrid(ballManager, 1, 15, Globals.BrickBlue.Width, Globals.Bounds.X/2, Globals.Bounds.Y/2, true, 45); //Just for testing
        //currentLevel = new LevelGrid(ballManager, 20, 20, Globals.BallBlue.Width*2.5f, Globals.Bounds.X/2, Globals.Bounds.Y/2, false, 0);
        player = new(ballManager);
        UI = new();
    }
    public void Init()
    {
        UI.Init(player);
    }

    public void Update()
    {
        ballManager.Update();
        currentLevel.Update(); //Also for testing, change to LevelGenerator.Update() which will handle the main level system to keep GameManager clean
        if (currentLevel.brickPlacer.bricks.Count <= 0) //Just for testing
        {
            currentLevel = new LevelGrid(ballManager, 1, 15, Globals.BrickBlue.Width, Globals.Bounds.X/2, Globals.Bounds.Y/2, true, 45);
        }
    
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