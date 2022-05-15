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
    public override List<int> PlayDice(Die[] die, UI userInterface)
    {
        List<int> diceValues = new List<int>();
        userInterface.CompRollingDicesDisplay(Name);


        for (int i = 0; i < die.Length; i++)
        {
            die[i] = new Die();
            int selectNum = die[i].RollDice();
            diceValues.Add(selectNum);
        }

        userInterface.DisplayDices(die);
        return diceValues;
    }

    public override List<int> PlayRemainingDices(UI userInterface, Die[] die,List<int> diceValues, int pairToKeep)
    {
        int selectNum;
        List<int> dicesToBeRolled = new List<int>();
        if (Attempts > 0)
        {
            userInterface.CompRemainingDicesDisplay(Name);
            for (int i = 0; i < diceValues.Count; i++)
            {
                if (diceValues[i] != pairToKeep)
                {
                    dicesToBeRolled.Add(i);
                }
            }
            foreach (int i in dicesToBeRolled)
            {
                selectNum = die[i].RollDice();
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

    public override void SetName(string name)
    {
        Name = name;
    }

    
}

