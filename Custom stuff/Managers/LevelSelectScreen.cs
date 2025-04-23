namespace Slutprojekt;

public class LevelSelectScreen
{
    private List<Rectangle> levelButtons = new();
    private List<string> levelNames = new() { "Level 1", "Level 2", "Level 3", "Level 4", "Level 5", "Level 6", "Level 7", "Level 8" };
    private LevelCombiner levelCombiner;
    private GameStateManager gameStateManager;
    private int buttonWidth = 200;
    private int buttonHeight = 50;
    private int buttonSpacing = 20;
    private float scrollOffset = 0f;
    private float scrollSpeed = 400f;
    private float maxVisibleButtons = 4;

    public LevelSelectScreen(LevelCombiner combiner, GameStateManager manager)
    {
        levelCombiner = combiner;
        gameStateManager = manager;
        InitializeButtons();
    }

    private void InitializeButtons()
    {
        int startY = (int)(Globals.Bounds.Y * 0.3f);
        for (int i = 0; i < levelNames.Count; i++)
        {
            levelButtons.Add(new Rectangle(
                (int)(Globals.Bounds.X / 2 - buttonWidth / 2),
                startY + (buttonHeight + buttonSpacing) * i,
                buttonWidth,
                buttonHeight
            ));
        }
    }

    public void Update()
    {
        var mouseState = Mouse.GetState();
        var keyboardState = Keyboard.GetState();
        
        if (keyboardState.IsKeyDown(Keys.Down))
            scrollOffset += scrollSpeed * Globals.TotalSeconds;
        if (keyboardState.IsKeyDown(Keys.Up))
            scrollOffset -= scrollSpeed * Globals.TotalSeconds;

        float maxScroll = Math.Max(0, (levelButtons.Count - maxVisibleButtons) * (buttonHeight + buttonSpacing));
        scrollOffset = Math.Clamp(scrollOffset, 0, maxScroll);

        var mousePos = new Point(mouseState.X, mouseState.Y);
        for (int i = 0; i < levelButtons.Count; i++)
        {
            var adjustedButton = new Rectangle(
                levelButtons[i].X,
                levelButtons[i].Y - (int)scrollOffset,
                levelButtons[i].Width,
                levelButtons[i].Height
            );

            if (adjustedButton.Contains(mousePos) && mouseState.LeftButton == ButtonState.Pressed)
            {
                SelectLevel(i);
            }
        }
    }

    private void SelectLevel(int index)
    {
        levelCombiner.Reset();
        switch (index)
        {
            case 0:
                levelCombiner.FirstLevel();
                break;
            case 1:
                levelCombiner.SecondLevel();
                break;
            case 2:
                //levelCombiner.ThirdLevel();
                break;
            case 3:
                //levelCombiner.FourthLevel();
                break;
            case 4:
                //levelCombiner.FifthLevel();
                break;
            case 5:
                //levelCombiner.SixthLevel();
                break;
            case 6:
                //levelCombiner.SeventhLevel();
                break;
            case 7:
                //levelCombiner.EighthLevel();
                break;
        }
        gameStateManager.ChangeState(GameState.CharacterSelect);
    }

    public void Draw()
    {
        string title = "Select Level";
        Vector2 titleSize = Globals.Font.MeasureString(title);
        Vector2 titlePos = new(Globals.Bounds.X / 2 - titleSize.X / 2, Globals.Bounds.Y * 0.15f);
        Globals.SpriteBatch.DrawString(Globals.Font, title, titlePos, Color.White);

        int startY = (int)(Globals.Bounds.Y * 0.3f);
        Rectangle viewport = new(0, startY, Globals.Bounds.X, (int)(buttonHeight + buttonSpacing) * (int)maxVisibleButtons);

        if (scrollOffset > 0)
        {    
            Globals.SpriteBatch.DrawString(Globals.Font, "▲", new Vector2(Globals.Bounds.X / 2 - 10, startY - 50), Color.White);
        }
        if (scrollOffset < (levelButtons.Count - maxVisibleButtons) * (buttonHeight + buttonSpacing))
        {
            Globals.SpriteBatch.DrawString(Globals.Font, "▼", new Vector2(Globals.Bounds.X / 2 - 10, viewport.Bottom + 50), Color.White);
        }

        for (int i = 0; i < levelButtons.Count; i++)
        {
            var adjustedButton = new Rectangle(
                levelButtons[i].X,
                levelButtons[i].Y - (int)scrollOffset,
                levelButtons[i].Width,
                levelButtons[i].Height
            );

            if (adjustedButton.Bottom >= viewport.Top && adjustedButton.Top <= viewport.Bottom)
            {
                Globals.SpriteBatch.Draw(Globals.Pixel, adjustedButton, Color.DarkGray);
                Vector2 textSize = Globals.Font.MeasureString(levelNames[i]);
                Vector2 textPos = new(
                    adjustedButton.Center.X - textSize.X / 2,
                    adjustedButton.Center.Y - textSize.Y / 2
                );
                Globals.SpriteBatch.DrawString(Globals.Font, levelNames[i], textPos, Color.White);
            }
        }
    }
}
