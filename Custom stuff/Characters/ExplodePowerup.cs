namespace Slutprojekt;
public class ExplodeCharacter : BaseCharacter
{
    public ExplodeCharacter(BallManager ballmanager, LevelCombiner levelCombiner) : base(ballmanager)
    {
        Powerup = new ExplodePowerup(ballmanager, levelCombiner);
        Name = "Explode";
    }
    public override string Description()
    {
        return $"{Powerup.Description()}";
    }

    public override void Draw()
    {
        // Draw the character texture at the specified position
        //Globals.SpriteBatch.Draw(Texture, Position, Color.White);
    }
}