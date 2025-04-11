namespace Slutprojekt;
public class BreakRedsCharacter : BaseCharacter
{
    public BreakRedsCharacter(BallManager ballmanager, LevelCombiner levelCombiner) : base(ballmanager)
    {
        Powerup = new BreakRedsPowerup(ballmanager, levelCombiner);
    }
    public override string Description()
    {
        return "";
    }

    public override void Draw()
    {
        // Draw the character texture at the specified position
        //Globals.SpriteBatch.Draw(Texture, Position, Color.White);
    }
}