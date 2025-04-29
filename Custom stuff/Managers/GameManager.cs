namespace Slutprojekt;
public class GameManager
{
    public BallManager ballManager = new();
    public Player player;
    public BaseCharacter character;
    public UI UI;
    public LevelCombiner levelCombiner;
    private Cannon cannon;
    private GameStateManager gameStateManager;
    private LevelSelectScreen levelSelectScreen;
    private CharacterSelectScreen characterSelectScreen;

    public GameManager()
    {
        gameStateManager = new GameStateManager();
        player = new(ballManager);
        levelCombiner = new(ballManager, player);
        
        cannon = new Cannon(ballManager, levelCombiner);
        UI = new();
        levelSelectScreen = new LevelSelectScreen(levelCombiner, gameStateManager);
        characterSelectScreen = new CharacterSelectScreen(ballManager, levelCombiner, gameStateManager, player);
        ScoreManager.Initialize();
    }
    public void Init()
    {
        UI.Init(player);
        levelCombiner.Reset();
    }

    public void Update()
    {
        switch (gameStateManager.CurrentState)
        {
            case GameState.LevelSelect:
                levelSelectScreen.Update();
                break;
            case GameState.CharacterSelect:
                characterSelectScreen.Update();
                levelCombiner.Update();
                break;
            case GameState.Playing:
                player.Update();
                ballManager.Update(player);
                cannon.Update();
                levelCombiner.Update();
                break;
        }
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(Globals.Pixel, new Rectangle(0, 0, Globals.Bounds.X, Globals.Bounds.Y), Color.Black);

        switch (gameStateManager.CurrentState)
        {
            case GameState.LevelSelect:
                levelSelectScreen.Draw();
                break;
            case GameState.CharacterSelect:
                levelCombiner.Draw();
                characterSelectScreen.Draw();
                break;
            case GameState.Playing:
                levelCombiner.Draw();
                cannon.Draw();
                Globals.SpriteBatch.Draw(Globals.Pixel, new Rectangle(0, 0, Globals.LeftWall, Globals.Bounds.Y), Color.Blue);
                Globals.SpriteBatch.Draw(Globals.Pixel, new Rectangle(Globals.RightWall, 0, Globals.Bounds.X-Globals.RightWall, Globals.Bounds.Y), Color.Pink);
                ballManager.Draw();
                UI.Draw();
                break;
        }
    }
}