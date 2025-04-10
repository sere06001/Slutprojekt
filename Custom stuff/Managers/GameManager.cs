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
        //character = new FireballCharacter(ballManager);
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

            var x = Globals.Bounds.X/2; //Bounds.X/2;
            var y = 50;
            Vector2 mousePosition = currentMouseState.Position.ToVector2();
            //ballManager.SpawnBall(new(x, y));
            ballManager.SpawnBall(new(mousePosition.X, mousePosition.Y + Globals.BallTexture.Height));
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