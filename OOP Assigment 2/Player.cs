using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


abstract class Player : IPlayer
{
    protected int Points { get; set; }
    protected string Name { get; set; }

    protected int Attempts { get; set; }

    public Player()
    {
        Points = 0;
        Attempts = 2;
        Name = "Player";
    }
    public void SetAttempts(int attempts)
    {
        Attempts = attempts;
    }
    public int GetAttempts()
    {
        return Attempts;
    }
    public virtual void SetName(string name)
    {
        Name = "Player";
    }

    public string GetName()
    {
        return Name;
    }
    public abstract List<int> PlayDice(Die[] die, UI userInterface);

    public abstract List<int> PlayRemainingDices(UI userInterface,Die[] die,List<int> diceValues, int pairToKeep);

    public void SetPoints(int points)
    {
        Points += points;
    }
    public int GetPoints()
    {
        return Points;
    }
}

