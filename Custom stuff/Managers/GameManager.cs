namespace Slutprojekt;
public class GameManager
{
    public BallManager ballManager = new();
    public Player player;
    public UI UI;
    private LevelBase currentLevel;
    private MouseState previousMouseState;
    private int degree = 45;

    public GameManager()
    {
        player = new(ballManager);
        //Change to LevelGenerator.Update() later, currentLevel is just for testing purposes

        //currentLevel = new LevelCircle(ballManager, 100f, 10, Globals.Bounds.X/2, Globals.Bounds.Y/2, false); //Just for testing
        currentLevel = new LevelGrid(ballManager, player, 1, 15, Globals.BrickBlue.Width, Globals.Bounds.X/2, Globals.Bounds.Y/2, true, degree); //Just for testing
        //currentLevel = new LevelGrid(ballManager, 20, 20, Globals.BallBlue.Width*2.5f, Globals.Bounds.X/2, Globals.Bounds.Y/2, false, 0);

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
        if (currentLevel.UseBricks)
        {
            if (currentLevel.brickPlacer.GetBricks().Count <= 0) //Just for testing
            {
                currentLevel = new LevelGrid(ballManager, player, 1, 15, Globals.BrickBlue.Width, Globals.Bounds.X/2, Globals.Bounds.Y/2, true, degree);
            }
        }
        else
        {
            if (currentLevel.circlePlacer.GetCircles().Count <= 0) //Just for testing
            {
                currentLevel = new LevelGrid(ballManager, player, 1, 15, Globals.BrickBlue.Width, Globals.Bounds.X/2, Globals.Bounds.Y/2, false, degree);
            }
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
        UI.Draw();
        currentLevel.Draw();
    }
}