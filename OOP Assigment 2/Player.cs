using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//The player class is an abstract class that serves as the foundation to the HumanPlayer class and CompPlayer class
//it inherits from the IPlayer interface
abstract class Player : IPlayer
{   // 3 protected properties , allowing it be private while accessable by the children classes
    protected int Points { get; set; }
    protected string Name { get; set; }
    protected int Attempts { get; set; }
    //'Standard' constructor , in case children classes don't define or something goes wrong in the definition
    public Player()
    {
        Points = 0;
        Attempts = 2;
        Name = "Player";
    }
    //Set attempts without directly calling the property
    public void SetAttempts(int attempts)
    {
        Attempts = attempts;
    }
    //Returns the number of attempts
    public int GetAttempts()
    {
        return Attempts;
    }
    //Virtual method to set the name , must be overridden 
    public virtual void SetName(string name)
    {
        Name = "Player";
    }
    //Returns the name value
    public string GetName()
    {
        return Name;
    }
    // Abstract method , the children must have a PlayDices method with these parameters
    public abstract List<int> PlayDices(Die[] die, UI userInterface);
    // Abstract method , makes sure the children classes have a PlayRemainingDices method, must be overridden 
    public abstract List<int> PlayRemainingDices(UI userInterface,Die[] die,List<int> diceValues, int pairToKeep);
    
    //Adds the number of points
    public void SetPoints(int points)
    {
        Points += points;
    }
    //return the total ammount of points
    public int GetPoints()
    {
        return Points;
    }
}

