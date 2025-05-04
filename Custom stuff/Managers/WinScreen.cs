namespace Slutprojekt;

public class WinScreen
{
    private List<Rectangle> buttons = new();
    private List<string> buttonTexts = new() { "Level Select", "Change Character", "Restart Level" };
    private LevelCombiner levelCombiner;
    private GameStateManager gameStateManager;
    private Player player;
    private BallManager ballManager;
    private readonly int buttonWidth = 200;
    private readonly int buttonHeight = 50;
    private readonly int buttonSpacing = 20;
    private MouseState previousMouseState;

    public WinScreen(LevelCombiner combiner, GameStateManager manager, Player player, BallManager ballManager)
    {
        levelCombiner = combiner;
        gameStateManager = manager;
        this.player = player;
        this.ballManager = ballManager;
        InitializeButtons();
    }

    private void InitializeButtons()
    {
        int startY = (int)(Globals.Bounds.Y * 0.6f);
        for (int i = 0; i < buttonTexts.Count; i++)
        {
            buttons.Add(new Rectangle(
                (int)(Globals.Bounds.X / 2 - buttonWidth / 2),
                startY + (buttonHeight + buttonSpacing) * i,
                buttonWidth,
                buttonHeight
            ));
        }
    }

    public void Update()
    {
        var currentMouseState = Mouse.GetState();
        var mousePos = new Point(currentMouseState.X, currentMouseState.Y);

        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i].Contains(mousePos) && 
                currentMouseState.LeftButton == ButtonState.Pressed && 
                previousMouseState.LeftButton == ButtonState.Released)
            {
                HandleButtonClick(i);
                break;
            }
        }

        previousMouseState = currentMouseState;
    }

    private void HandleButtonClick(int index)
    {
        switch (index)
        {
            case 0:
                gameStateManager.ChangeState(GameState.LevelSelect);
                break;
            case 1:
                gameStateManager.ChangeState(GameState.CharacterSelect);
                break;
            case 2:
                ballManager.Reset();
                levelCombiner.Reset();
                levelCombiner.player.currentLevel = player.currentLevel;
                gameStateManager.ChangeState(GameState.CharacterSelect);
                break;
        }
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(Globals.Pixel, new Rectangle(0, 0, Globals.Bounds.X, Globals.Bounds.Y), new Color(0, 0, 0, 200));

        string title = "Level Completed";
        Vector2 titleSize = Globals.Font.MeasureString(title);
        Vector2 titlePos = new(Globals.Bounds.X / 2 - titleSize.X / 2, Globals.Bounds.Y * 0.15f);
        Globals.SpriteBatch.DrawString(Globals.Font, title, titlePos, Color.White);

        // Draw stats
        float statsY = Globals.Bounds.Y * 0.3f;
        float statsX = Globals.Bounds.X / 2;
        
        string highScore = $"High Score: {ScoreManager.GetHighScore(player.currentLevel)}";
        string levelScore = $"Level Score: {player.ScoreLevel}";
        string ballsLeft = $"Balls Left: {ballManager.BallsLeft}";

        Vector2 highScorePos = new(statsX - Globals.Font.MeasureString(highScore).X / 2, statsY);
        Vector2 levelScorePos = new(statsX - Globals.Font.MeasureString(levelScore).X / 2, statsY + 40);
        Vector2 ballsLeftPos = new(statsX - Globals.Font.MeasureString(ballsLeft).X / 2, statsY + 80);

        Globals.SpriteBatch.DrawString(Globals.Font, highScore, highScorePos, Color.Yellow);
        Globals.SpriteBatch.DrawString(Globals.Font, levelScore, levelScorePos, Color.White);
        Globals.SpriteBatch.DrawString(Globals.Font, ballsLeft, ballsLeftPos, Color.White);


        var mousePos = Mouse.GetState().Position;

        for (int i = 0; i < buttons.Count; i++)
        {
            Color buttonColor = buttons[i].Contains(mousePos) ? Color.Gray : Color.DarkGray;
            Globals.SpriteBatch.Draw(Globals.Pixel, buttons[i], buttonColor);
            
            Vector2 textSize = Globals.Font.MeasureString(buttonTexts[i]);
            Vector2 textPos = new(
                buttons[i].Center.X - textSize.X / 2,
                buttons[i].Center.Y - textSize.Y / 2
            );
            Globals.SpriteBatch.DrawString(Globals.Font, buttonTexts[i], textPos, Color.White);
        }
    }
}
