using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Human Player
class HumanPlayer : Player
{

    public override void SetName()
    {
        string name = string.Empty;

        while (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Please enter your name: ");
            name = Console.ReadLine();
        }
        Name = name;
    }
    public override List<int> PlayDice()
    {
        List<int> diceValues = new List<int>();
        Console.WriteLine("{0} Please press any key to roll your dices", Name);
        Console.ReadKey();
        Console.WriteLine("{0} rolling dices", Name);
        Thread.Sleep(3000);

        for (int i = 0; i < die.Length; i++)
        {
            die[i] = new Die();
            int selectNum = die[i].Numbers[random.Next(0, die[i].Numbers.Length - 1)];
            die[i].SetValueOnTop(selectNum);
            diceValues.Add(selectNum);
        }

        Console.WriteLine("The dices have been rolled, those are the values you got: ");
        foreach (int diceValue in diceValues) { Console.Write(diceValue + " "); }
        Console.WriteLine("\n");
        return diceValues;
    }

    public override List<int> PlayRemainingDices(List<int> diceValues, int pairToKeep)
    {
        int selectNum;
        List<int> dicesToBeRolled = new List<int>();
        if (Attempts > 0)
        {
            Console.WriteLine("Please press any key to confirm the re-roll of dices or enter 'NO' to keep your dices");
            if (Console.ReadLine().ToUpper() == "NO")
            {
                Attempts = 0;
                return diceValues;
            }

            for (int i = 0; i < diceValues.Count; i++)
            {
                if (diceValues[i] != pairToKeep)
                {
                    dicesToBeRolled.Add(i);
                }
            }
            foreach (int i in dicesToBeRolled)
            {
                selectNum = die[i].Numbers[random.Next(0, die[i].Numbers.Length - 1)];
                die[i].SetValueOnTop(selectNum);
            }

            diceValues.Clear();

            if (Attempts > 0)
            {
                for (int i = 0; i < die.Length; i++)
                {
                    diceValues.Add(die[i].GetValueOnTop());
                }
                Attempts--;
                return diceValues;
            }
        }
        diceValues.Clear();
        return diceValues;
    }
}


