namespace Slutprojekt;
public class Player
{
    public BasePowerup Powerup { get; set; } //Assign powerup here so stuff can call player.Powerup likewise with character etc
    public BaseCharacter Character { get; set; }

}