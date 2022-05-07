﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class Player
{
    private int Points { get; set; }
    private string Name { get; set; }

    int rounds = 2;

    Die[] die = new Die[5];
    Random random = new Random();

    public void SetName()
    {
        string name = string.Empty;

        while (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Please enter your name: ");
            name = Console.ReadLine();
        }
        Name = name;
    }

    public string GetName()
    {
        return Name;
    }
    public List<int> PlayDice()
    {
        List<int> diceValues = new List<int>();
        Console.WriteLine("{0} Please press 'Enter' to roll your dices",Name);
        Console.ReadKey();
        Console.WriteLine( "{0} rolling dices Dices", Name);
        Thread.Sleep(3000);
        //for (int i = 0; i < 5; i++)
        //{
        //    int selectNum = die.Numbers[random.Next(0, die.Numbers.Length - 1)];
        //    diceValues.Add(selectNum);
        //}
        for (int i = 0; i < die.Length; i++)
        {
            die[i] = new Die();
            int selectNum = die[i].Numbers[random.Next(0, die[i].Numbers.Length - 1)];
            die[i].SetValueOnTop(selectNum);
            diceValues.Add(selectNum);
        }

        Console.WriteLine("The dices have been rolled, those are the values you got: ");
        foreach (int diceValue in diceValues) { Console.Write(diceValue + " "); }
        Console.WriteLine("\n");
        return diceValues;
    }
    public List<int> PlayRemainingDices(List<int> diceValues, int[] NofKind)
    {
        int selectNum;
        List<int> dicesToBeRolled = new List<int>();
        if (rounds > 0)
        {   
            
            Console.WriteLine("You have not scored any points, however you have 2 of-a-kind");
            Console.WriteLine("Would you like to roll the remaining dices again ? Press any key to confirm, enter 'No' to keep the dices");
            if (Console.ReadLine().ToUpper()== "NO")
            {
                rounds = 0;
                return diceValues;
            }
            Console.ReadKey();
            for (int i = 0; i < diceValues.Count; i++)
            {
                if (diceValues[i] != NofKind[0])
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

            if (rounds > 0)
            {
                for (int i = 0; i < die.Length; i++)
                {
                    diceValues.Add(die[i].GetValueOnTop());
                }
                rounds--;
                return diceValues;
            }
        }
        diceValues.Clear();
        return diceValues;
    }
    public void SetPoints(int points)
    {
        Points += points;
    }
    public int GetPoints()
    {
        return Points;
    }
}

