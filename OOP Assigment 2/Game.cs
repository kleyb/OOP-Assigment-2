using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Game
{
    HumanPlayer player1 = new HumanPlayer();
    HumanPlayer player2 = new HumanPlayer();
    HumanPlayer player3 = new HumanPlayer();
    CompPlayer compPlayer = new CompPlayer();
    private Die[] die = new Die[5];
    UI userInterface = new UI();
    
    

    public void ResetAttemptsNumber(HumanPlayer player1, HumanPlayer player2, HumanPlayer player3)
    {
        player1.SetAttempts(2);
        player2.SetAttempts(2);
        player3.SetAttempts(2);
    }

    public void ResetAttemptsNumber(Player player1,Player player2)
    {        
        player1.SetAttempts(2);
        player2.SetAttempts(2);
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
            CheckforNumbers(player1.PlayDice(die,userInterface), player1);
            CheckforNumbers(player2.PlayDice(die,userInterface), player2);
            ResetAttemptsNumber(player1, player2);
            userInterface.DisplayScoreBoard(player1,player2);
            if (player1.GetPoints() >= 10 || player2.GetPoints() >= 10)
            {
                userInterface.DisplayWinner(FindWinner(player1, player2));
                break;
            }
            Console.WriteLine("Please press any key to start next round");
            Console.ReadKey();
            Console.WriteLine("Next round starting...");
            Thread.Sleep(3000);
            Console.Clear();
        }   
    }
    //Player vs Player vs Player 
    public void Play3PVP ()
    {
        Console.Clear();

        Console.WriteLine("Please enter the name of the Players \n");
        player1.SetName();
        player2.SetName();
        player3.SetName();

        while (true)
        {
            CheckforNumbers(player1.PlayDice(die,userInterface), player1);
            CheckforNumbers(player2.PlayDice(die,userInterface), player2);
            CheckforNumbers(player3.PlayDice(die,userInterface), player3);
            ResetAttemptsNumber(player1,player2,player3);

            userInterface.DisplayScoreBoard(player1, player2,player3);
            if (player1.GetPoints() >= 10 || player2.GetPoints() >= 10 || player3.GetPoints() >= 10)
            {
                userInterface.DisplayWinner(FindWinner(player1, player2,player3));
                break;
            }
            Console.WriteLine("Please press any key to start next round");
            Console.ReadKey();
            Console.WriteLine("Next round starting...");
            Thread.Sleep(3000);
            Console.Clear();

        }
    }
    //Player vs Computer Player
    public void PlayVSComp()
    {
        Console.Clear();


        Console.WriteLine("Please enter the name of the Player \n");
        player1.SetName();
        compPlayer.SetName();
        while (true)
        {
            CheckforNumbers(player1.PlayDice(die,userInterface), player1);
            CheckforNumbers(compPlayer.PlayDice(die,userInterface), compPlayer);

            ResetAttemptsNumber(player1, compPlayer);
            userInterface.DisplayScoreBoard(player1, compPlayer);

            if (player1.GetPoints() >= 10 || compPlayer.GetPoints() >= 10)
            {
                userInterface.DisplayWinner(FindWinner(player1, compPlayer)); 
                break;
            }
            Console.WriteLine("Please press any key to start next round");
            Console.ReadKey();
            Console.WriteLine("Next round starting...");
            Thread.Sleep(3000);
            Console.Clear();
        }
    }

    public void CheckforNumbers(List<int> diceValues, HumanPlayer player)
    {
        Dictionary<int,int> frequency = new Dictionary<int,int>();
        List<int> temp = new List<int>();
        string choice;
        int pairToKeep =0;
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

            diceValues = player.PlayRemainingDices(die,diceValues, pairToKeep);
            if (diceValues.Count <= 0)
            {
                Console.WriteLine("You have already rolled twice ,no more rollings are allowed in this round." +
                    " You have scored 0 points in this round");
                player.SetPoints(0);
            }
            else
            {
                userInterface.DisplayDices(die);
                CheckforNumbers(diceValues, player);
            }
        }
        else if(!temp.Any() && scored == false)
        {
            Console.WriteLine("Unfortunally, you have not scored any points in this round. You scored 0 points");
        }
    }

    public void CheckforNumbers(List<int> diceValues, CompPlayer compPlayer)
    {
        Dictionary<int, int> frequency = new Dictionary<int, int>();
        List<int> temp = new List<int>();
        string choice;
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
                        Console.WriteLine("{0} scored 3 points! ", compPlayer.GetName());
                        compPlayer.SetPoints(3);
                    }
                    else if (frequency[i] == 4)
                    {
                        Console.WriteLine("{0} scored 6 points! ", compPlayer.GetName());
                        compPlayer.SetPoints(6);
                    }
                    else if (frequency[i] == 5)
                    {
                        Console.WriteLine("{0} scored 12 points! ", compPlayer.GetName());
                        compPlayer.SetPoints(12);
                    }
                    scored = true;
                    break;
                }
                temp.Add(i);
            }
        }

        if (temp.Any() && scored == false)
        {
            if (temp.Count > 1)
            {
                pairToKeep = temp.First();
            }

            diceValues = compPlayer.PlayRemainingDices(die,diceValues, pairToKeep);
            if (diceValues.Count <= 0)
            {
                Console.WriteLine("{0} has re-rolled the dices 2 times , no more rollings allowed in this round", compPlayer.GetName()); 
                compPlayer.SetPoints(0);
            }
            else
            {
                userInterface.DisplayDices(diceValues);
                CheckforNumbers(diceValues, compPlayer);
            }
        }
        else if (!temp.Any() && scored == false)
        {
            Console.WriteLine("{0} scored 0 points",compPlayer.GetName());
        }
    }

    public Player FindWinner(Player player1, Player player2)
    {        
        if (player1.GetPoints() > player2.GetPoints())
        {
            return player1;
        }
        else if (player1.GetPoints() < player2.GetPoints())
        {
            return player2;
        }
        else
        {
            return null;
        }
    }
    public Player FindWinner(HumanPlayer player1, HumanPlayer player2, HumanPlayer player3)
    {
        if (player1.GetPoints() > player2.GetPoints() && player1.GetPoints() > player3.GetPoints())
        {
            return player1;
        }
        else if (player1.GetPoints() < player2.GetPoints() && player3.GetPoints() < player2.GetPoints())
        {
            return player2;
        }
        else if (player3.GetPoints()> player1.GetPoints() && player3.GetPoints() > player2.GetPoints())
        {
            return player3;
        }
        else
        {   //returns null if there is no clear winner 
            return null;
        }
    }
}

