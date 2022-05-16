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
    public override List<int> PlayDices(Die[] die, UI userInterface)
    {   //Starts by creating a List of dice values
        List<int> diceValues = new List<int>();
        //display to the console what the Computer player is currently doing
        userInterface.CompRollingDicesDisplay(Name);
        //iterates through every dice in the Die array and rolls them , takes value from RollDice()
        // and adds it into the diceValues list
        for (int i = 0; i < die.Length; i++)
        {
            die[i] = new Die();
            diceValues.Add(die[i].RollDice());
        }
        // Display the dice values
        userInterface.DisplayDices(die);
        //return diceValues lit
        return diceValues;
    }

    public override List<int> PlayRemainingDices(UI userInterface, Die[] die,List<int> diceValues, int pairToKeep)
    {// if the number of attempts is hight than 0 continues, else returns an empty list
        if (Attempts > 0)
        {   //Displays to console what the compPlayer is doing
            userInterface.CompRemainingDicesDisplay(Name);
            
            // Goes through every value in the dice values
            for (int i = 0; i < diceValues.Count; i++)
            {   // if the value is not the same as the 'pairToKeep' , the two of a kind that the user wishes to keep
                if (diceValues[i] != pairToKeep)
                {   //Re-roll dice
                    die[i].RollDice();
                }
            }
            //Clears the values on the diceValue list
            diceValues.Clear();
            
            //goes through every dice
            for (int i = 0; i < die.Length; i++)
            {//Gets the value on top of every dice and adds it into diceValues list
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
    //Override of the virtual method SetName , take name pre-defined and assigns it to the property
    public override void SetName(string name)
    {
        Name = name;
    }

    
}

