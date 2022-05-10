using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class Game
{
    Player player1 = new Player();
    Player player2 = new Player();
    public void SetAttemptsNumber(Player player1,Player player2)
    {
        player1.ResetAttempts();
        player2.ResetAttempts();
    }
    public void SetAttemptsNumber(Player player)
    {
        player.ResetAttempts();
    }
    public void DisplayScoreBoard()
    {
        
        Console.WriteLine("\n Game Board Score:");
        Console.WriteLine("Player 1 has {0} points",player1.GetPoints());
        Console.WriteLine("Player 2 has {0} points\n",player2.GetPoints());
    }
    public void DisplayDices( List<int> dices)
    {
        foreach (int dice in dices)
        {
            Console.Write(dice + " ");
        }
        Console.WriteLine("\n");
    }
    // Player vs Player
    public void PlayPVP()
    {
        Console.Clear();

        Console.WriteLine("Please enter the name of the Players \n");
        player1.SetName();
        player2.SetName();


        while (true)
        {
            CheckforNumbers(player1.PlayDice(), player1);
            CheckforNumbers(player2.PlayDice(), player2);
            SetAttemptsNumber(player1, player2);
            DisplayScoreBoard();
            if (player1.GetPoints() >= 10 || player2.GetPoints() >= 10) break;
            Console.WriteLine("Please press any key to start next round");
            Console.ReadKey();
            Console.WriteLine("Next round starting...");
            Thread.Sleep(3000);
            Console.Clear();

        }
        if (player1.GetPoints() > player2.GetPoints())
        {
            Console.WriteLine("{0} has won the game with {1} points ", player1.GetName(), player1.GetPoints());
        }
        else if (player1.GetPoints() < player2.GetPoints())
        {
            Console.WriteLine("{0} has won the game with {1} points ", player2.GetName(), player2.GetPoints());
        }
        else
        {
            Console.WriteLine("The game has ended in a tie! ");
            DisplayScoreBoard();
        }

    }
    public void CheckforNumbers(List<int> diceValues, Player player)
    {
        Dictionary<int,int> frequency = new Dictionary<int,int>();
        List<int> temp = new List<int>();
        string choice = "";
        int pairToKeep = 0;
        bool scored = false;


        foreach (int i in diceValues)
        {
            if (!frequency.ContainsKey(i))
            {
                frequency.Add(i, 1);
            }
            else
            {
                frequency[i]++;
            }
        }
        foreach (int i in frequency.Keys)
        {
            if (frequency[i] >= 2)
            {
                if (frequency[i] >= 3)
                {
                    if (frequency[i] == 3)
                    {
                        Console.WriteLine("{0} You have scored 3 points! ",player.GetName());
                        player.SetPoints(3);
                    }
                    else if (frequency[i] == 4)
                    {
                        Console.WriteLine("{0} You have scored 6 points! ", player.GetName());
                        player.SetPoints(6);
                    }
                    else if (frequency[i] == 5)
                    {
                        Console.WriteLine("{0} You have scored 12 points! ", player.GetName());
                        player.SetPoints(12);
                    }
                    scored = true;
                    break;
                }
                temp.Add(i);
            }
        }

        if (temp.Any() && scored == false)
        {
            pairToKeep = temp.First();
            if (temp.Count > 1)
            {
                Console.WriteLine("You have not scored any points at this round, however you have 2 of-a-kind twice " +
                    "this allows you to roll the dices again, please choose which '2 of-a-kind' would you like to keep");
                
                while (true)
                {
                    Console.WriteLine("Please enter '1' to keep {0} or enter '2' to keep {1}: ", temp[0], temp[1]);
                    choice = Console.ReadLine();
                    if (choice == "1" || choice == "2") break;
                } 

                if (choice == "1") pairToKeep = temp[0];
                else pairToKeep = temp[1];
            }

            diceValues = player.PlayRemainingDices(diceValues, pairToKeep);
            if (diceValues.Count <= 0)
            {
                Console.WriteLine("You have already rolled twice ,no more rollings are allowed in this round." +
                    " You have scored 0 points in this round");
                player.SetPoints(0);
                //if (player.GetPoints() == 0) Console.WriteLine("Unfortunally, you have not scored any points in this round");
            }
            else
            {
                DisplayDices(diceValues);
                CheckforNumbers(diceValues, player);
            }
        }
        else if(!temp.Any() && scored == false)
        {
            Console.WriteLine("Unfortunally, you have not scored any points in this round. You scored 0 points");
        }
    }
}

