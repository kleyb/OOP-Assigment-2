﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


interface IPlayer
{
    public List<int> PlayDice();

    public void SetAttempts(int attempts);

    public void SetName();


}
