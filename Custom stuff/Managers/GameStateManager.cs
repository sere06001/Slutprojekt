namespace Slutprojekt;

public enum GameState
{
    MainMenu,
    LevelSelect,
    CharacterSelect,
    Playing,
    Win,
    Paused
}

public class GameStateManager
{
    public GameState CurrentState { get; private set; } = GameState.LevelSelect;

    public void ChangeState(GameState newState)
    {
        CurrentState = newState;
    }
}
