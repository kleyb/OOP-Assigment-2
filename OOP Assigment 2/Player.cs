using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class Player
{
    private int Points { get; set; }
    private string Name { get; set; }

    public void GetName()
    {
        string name = string.Empty;

        while (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Please enter your name: ");
            name = Console.ReadLine();
        }
    }
    public List<int> PlayDice()
    {
        Die[] die = new Die[5];
        Random random = new Random();
        List<int> diceValues = new List<int>();
        Console.WriteLine("Please press 'Enter' to roll your dices");
        Console.WriteLine( "rolling dices Dices");
        //for (int i = 0; i < 5; i++)
        //{
        //    int selectNum = die.Numbers[random.Next(0, die.Numbers.Length - 1)];
        //    diceValues.Add(selectNum);
        //}
        for (int i = 0; i < die.Length; i++)
        {
            die[i] = new Die();
            int selectNum = die[i].Numbers[random.Next(0, die[i].Numbers.Length - 1)];
            diceValues.Add(selectNum);
        }

        Console.WriteLine("The dices have been rolled, those are the values you got: ");
        foreach (int diceValue in diceValues) { Console.Write(diceValue + " "); }
        
        return diceValues;
    }
    public void SetPoints(int points)
    {
        Points += points;
    }
    public int GetPoints()
    {
        return Points;
    }

}

