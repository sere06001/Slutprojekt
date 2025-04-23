namespace Slutprojekt;

public enum GameState
{
    LevelSelect,
    CharacterSelect,
    Playing
}

public class GameStateManager
{
    public GameState CurrentState { get; private set; } = GameState.LevelSelect;

    public void ChangeState(GameState newState)
    {
        CurrentState = newState;
    }
}
