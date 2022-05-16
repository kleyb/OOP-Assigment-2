using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This interface makes sure the classes that inherits it will have the following methods:
interface IPlayer
{   //A play dice method , to play the dices
    public List<int> PlayDices(Die[] die,UI userinterface);
    //A set attempts , to set and reset the number of attempts allowed
    public void SetAttempts(int attempts);
    // A set name to give every player a name
    public void SetName(string name);


}

