using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Die : IDie
{   //Create a new Random Object
    private Random random = new Random();
    //The array numbers hold all the numbers from the dices
    private int[] Numbers = { 1, 2, 3, 4, 5, 6 };
    
    //The value on top property holds the value that is on the top of the dice when rolled
    private int ValueOnTop { get; set; }
  
    //Returns the current value on top ( face) 
    public int GetValueOnTop()
    {
        return ValueOnTop;
    }
    //returns a random value from the array Numbers ,and also assigns it into ValueOnTop property
    public int RollDice()
    {   //Uses the Random Obj to get a random value between 0 and the last element in the array
        ValueOnTop = Numbers[random.Next(0, Numbers.Length - 1)];
        //return the value on top
        return ValueOnTop;
    }
}

