namespace Slutprojekt;
public class GameManager
{
    public BallManager ballManager = new();
    public Player player;
    public UI UI;
    public LevelGenerator levelGenerator;
    private MouseState previousMouseState;

    public GameManager()
    {
        player = new(ballManager);
        levelGenerator = new(ballManager, player);
        //Change to LevelGenerator.Update() later, currentLevel is just for testing purposes

        UI = new();
    }
    public void Init()
    {
        UI.Init(player);
        levelGenerator.Init();
    }

    public void Update()
    {
        ballManager.Update();
        levelGenerator.Update();

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
        levelGenerator.Draw();
    }
}