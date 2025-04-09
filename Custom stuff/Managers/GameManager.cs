namespace Slutprojekt;
public class GameManager
{
    public BallManager ballManager = new();
    public Player player;
    public BaseCharacter character;
    public UI UI;
    public LevelGenerator levelGenerator;
    public LevelCombiner levelCombiner;
    private MouseState previousMouseState;

    public GameManager()
    {
        character = new DuplicateBallCharacter(ballManager);
        //character = new RespawnBallCharacter(ballManager);
        player = new(ballManager, character);
        //PowerupHandler.player = player;
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
        player.Update();
        ballManager.Update(player);
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