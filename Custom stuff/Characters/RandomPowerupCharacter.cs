namespace Slutprojekt;
public class RandomPowerupCharacter : BaseCharacter
{
    public RandomPowerupCharacter(BallManager ballmanager, LevelCombiner levelCombiner) : base(ballmanager)
    {
        Powerup = new ExplodePowerup(ballmanager, levelCombiner); //Placeholder
        Name = "Shark";
    }
    public override string Description()
    {
        return $"Gets a new random powerup on hit.";
    }

    public override void Draw()
    {
        // Draw the character texture at the specified position
        //Globals.SpriteBatch.Draw(Texture, Position, Color.White);
    }
}