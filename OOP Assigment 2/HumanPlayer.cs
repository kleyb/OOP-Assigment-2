using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Human Player
class HumanPlayer : Player
{

    public override void SetName(string name)
    {
       
        Name = name;
    }
    public override List<int> PlayDice(Die[] die, UI userInterface)
    {
        List<int> diceValues = new List<int>();
        userInterface.HumanRollingDicesDisplay(Name);

        for (int i = 0; i < die.Length; i++)
        {
            die[i] = new Die();
            int selectNum = die[i].RollDice();
            diceValues.Add(selectNum);
        }

        userInterface.DisplayDices(die);
        return diceValues;
    }

    public override List<int> PlayRemainingDices(UI userInterface,Die[] die,List<int> diceValues, int pairToKeep)
    {
        int selectNum;
        List<int> dicesToBeRolled = new List<int>();
        if (Attempts > 0)
        {
            if (userInterface.PlayerRemainingDicesDisplay() == false)
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
}


