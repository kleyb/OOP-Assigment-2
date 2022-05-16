using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Human Player
class HumanPlayer : Player
{
    //Override of the virtual method SetName , takes the name passed by the user and assigns it to the property
    public override void SetName(string name)
    {       
        Name = name;
    }
    // Override and Implementation the the abstract PlayDices
    public override List<int> PlayDices(Die[] die, UI userInterface)
    {
        //Starts by creating a List of dice values
        List<int> diceValues = new List<int>();
        //Display rolling dices UI and waits for user input
        userInterface.HumanRollingDicesDisplay(Name);
        //iterates through every dice in the Die array and rolls them , assigns the value on top into selectNum
        // the adds it into the diceValues list
        for (int i = 0; i < die.Length; i++)
        {
            die[i] = new Die();
            int selectNum = die[i].RollDice();
            diceValues.Add(selectNum);
        }
        // Display the dice values
        userInterface.DisplayDices(die);
        //return the diceValues list
        return diceValues;
    }

    public override List<int> PlayRemainingDices(UI userInterface,Die[] die,List<int> diceValues, int pairToKeep)
    {//
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
                    die[i].RollDice();
                }
            }
            //foreach (int i in dicesToBeRolled)
            //{
            //    die[i].RollDice();
            //}

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


