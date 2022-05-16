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
        //iterates through every dice in the Die array and rolls them , takes the value from RollDice()
        // and adds it into the diceValues list
        for (int i = 0; i < die.Length; i++)
        {
            die[i] = new Die();
            diceValues.Add(die[i].RollDice());
        }
        // Display the dice values
        userInterface.DisplayDices(die);
        //return the diceValues list
        return diceValues;
    }
    //Overrides the abstract method from Player Class , re-rolls the remaining dices
    public override List<int> PlayRemainingDices(UI userInterface,Die[] die,List<int> diceValues, int pairToKeep)
    {// if the number of attempts is hight than 0 continues, else returns an empty list
        if (Attempts > 0)
        {   //Request confirmation from the player that he wants to replay the dices
            //if false returns the diceValues as it is and set Attempts to 0
            if (userInterface.PlayerRemainingDicesDisplay() == false)
            {
                Attempts = 0;
                return diceValues;
            }
            // Goes through every value in the dice values
            for (int i = 0; i < diceValues.Count; i++)
            {   // if the value is not the same as the 'pairToKeep' , the two of a kind that the user wishes to keep
                if (diceValues[i] != pairToKeep)
                {   //then it re-rools the dices
                    die[i].RollDice();
                }
            }
            //Clears the values on the diceValue list
            diceValues.Clear();

            //Goes through every dice
            for (int i = 0; i < die.Length; i++)
            {   //Gets the value on top of every dice and adds it into diceValues list
                diceValues.Add(die[i].GetValueOnTop());
            }
            //decreases the number of attempts by 1
            Attempts--;
            //return diceValues list
            return diceValues;
        }
        //if the number of attempts is 0 , then clears the diceValues list and returns it
        diceValues.Clear();
        return diceValues;
    }
}


