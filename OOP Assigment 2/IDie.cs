﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Die interface makes a contact between the classes that inherits from it
//that makes sure that there are implmentation of the following methods:
interface IDie
{
    // Get value on top , to allow the game to get this value indirectly
    public int GetValueOnTop();
    // The RollDice value , 'rolls' the dices by randomly choosing a value 
    public int RollDice();
}

