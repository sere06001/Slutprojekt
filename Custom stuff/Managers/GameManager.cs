namespace Slutprojekt;
public class GameManager
{
    public BallManager ballManager = new();
    public Player player;
    public UI UI;
    public LevelGenerator levelGenerator;
    public LevelCombiner levelCombiner;
    private MouseState previousMouseState;

    public GameManager()
    {
        player = new(ballManager);
        levelCombiner = new(ballManager, player);
        levelGenerator = new(ballManager, player, levelCombiner);
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
        player.Update();
        if (ballManager.balls.Count <= 0)
        {
            player.ResetScoreMultiplier();
        }
        levelGenerator.Update();

        MouseState currentMouseState = Mouse.GetState();
        
        if (ballManager.BallsLeft > 0 &&
            currentMouseState.LeftButton == ButtonState.Pressed &&
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