using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Computer Player
// Computer class inherits from the abstract player class , it overrides the abstracts methods 'PlayDice', 'PlayRemainingDices' and the virtual method 'SetName'
// its unique and different from the player class 
class CompPlayer : Player
{
    public override List<int> PlayDice()
    {
        List<int> diceValues = new List<int>();
        Console.WriteLine("{0} is rolling the dices", Name);
        Thread.Sleep(3000);

        for (int i = 0; i < die.Length; i++)
        {
            die[i] = new Die();
            int selectNum = die[i].Numbers[random.Next(0, die[i].Numbers.Length - 1)];
            die[i].SetValueOnTop(selectNum);
            diceValues.Add(selectNum);
        }

        Console.WriteLine("The dices have been rolled, {0} got these values: ",Name);
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
            Console.WriteLine("{0} re-rolling dices ",Name);
            Thread.Sleep(3000);
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

    public override void SetName()
    {
        Name = "Computer Player";
    }

    
}

