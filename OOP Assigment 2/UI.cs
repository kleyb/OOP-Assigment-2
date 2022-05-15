using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//User interface handles the I/O ( input and displays)
class UI
{
    public void DisplayMenu(Game game)
    {
        int input;

        while (true)
        {
            Console.WriteLine("Please select your game mode by entering it's number on the list : ");
            Console.WriteLine("1. Player VS Player");
            Console.WriteLine("2. Player VS Player VS Player");
            Console.WriteLine("3. Player vs Comp");
            Console.WriteLine("4. Exit Game");
            try
            {
                input = int.Parse(Console.ReadLine());
                GameMenu(game, input);
                break;
            }

            catch (InvalidSelectionException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter only numbers");
            }

        }
    }
    public void GameMenu(Game game, int input)
    {
        while (true)
        {
            if (input == 1)
            {
                game.PlayPVP();
                break;
            }
            else if (input == 2)
            {
                game.Play3PVP();
                break;
            }
            else if (input == 3)
            {
                game.PlayVSComp();
                break;
            }
            else if (input == 4)
            {
                Environment.Exit(0);
            }
            else
            {
                throw new InvalidSelectionException("Invalid selection, please enter a number from the menu ");

            }
        }
    }

    public void DisplayScoreBoard(Player player1, Player player2)
    {

        Console.WriteLine("\n Game Board Score:");
        Console.WriteLine("{0} has {1} points", player1.GetName(), player1.GetPoints());
        Console.WriteLine("{0} has {1} points\n", player2.GetName(), player2.GetPoints());
    }
    public void DisplayScoreBoard(HumanPlayer player1, HumanPlayer player2, HumanPlayer player3)
    {
        Console.WriteLine("\n Game Board Score:");
        Console.WriteLine("{0} has {1} points", player1.GetName(), player1.GetPoints());
        Console.WriteLine("{0} has {1} points", player2.GetName(), player2.GetPoints());
        Console.WriteLine("{0} has {1} points\n", player3.GetName(), player3.GetPoints());
    }

    public void DisplayWinner(Player player)
    {

        if (player == null)
        {
            Console.WriteLine("The game ended in a tie! ");
        }
        else
        {
            Console.WriteLine("{0} has won the game with {1} points ", player.GetName(), player.GetPoints());
        }
    }

    //Display Dices
    public void DisplayDices(Die[] die)
    {
        foreach (var dice in die)
        {
            Console.Write(dice.GetValueOnTop() + " ");
        }
        Console.WriteLine("\n");
    }
    //Display Dices Values
    public void DisplayDices(List<int> diceValues)
    {
        foreach (var values in diceValues)
        {
            Console.Write(values + " ");
        }
        Console.WriteLine("\n");
    }

    public bool EndOfGameMenu()
    {
        // bool playagain = true;
        int input;
        Console.WriteLine("Please select one of the options bellow:");
        Console.WriteLine("1. Play Again");
        Console.WriteLine("2. Exit Game");
        while (true)
        {
            try
            {
                input = int.Parse(Console.ReadLine());
                if (input == 1)
                {
                    return true;
                }
                else if (input == 2)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter only numbers");
                continue;
            }
        }

    }

    public void DisplayPointsScored(Player player, int points)
    {
        if (points == 0)
        {
            Console.WriteLine("No points scored in this round. {0} You scored 0 points", player.GetName());
        }
        else
        {
            Console.WriteLine("{0} scored {1} points! ", player.GetName(), points);
        }
    }
    public int SelectDicesToKeep(List<int> temp)
    {
        int choice;
        Console.WriteLine("You have not scored any points at this round, however you have 2 of-a-kind twice " +
                    "this allows you to roll the dices again, please choose which '2 of-a-kind' would you like to keep");

        while (true)
        {
            Console.WriteLine("Please enter '1' to keep {0} or enter '2' to keep {1}: ", temp[0], temp[1]);

            try
            {
                choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    return temp[0];
                }
                else if (choice == 2)
                {
                    return temp[1];
                }
                else
                {
                    throw new InvalidSelectionException("Invalid Selection , please enter '1' or '2' ");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }

    public void SetPlayersName(HumanPlayer player)
    {
        Console.WriteLine("Please enter the name of the Player \n");
        string name = string.Empty;

        while (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Please enter your name: ");
            name = Console.ReadLine();
        }

        player.SetName(name);

    }
    public void SetPlayersName(CompPlayer compPlayer)
    {
        compPlayer.SetName("Computer Player");
    }

    public void DisplayNextRoundMessage()
    {
        Console.WriteLine("Please press any key to start next round");
        Console.ReadKey();
        Console.WriteLine("Next round starting...");
        Thread.Sleep(3000);
        Console.Clear();
    }

    public void DisplayNoMoreRounds(CompPlayer compPlayer)
    {
        Console.WriteLine("{0} has re-rolled the dices 2 times , no more rollings allowed in this round", compPlayer.GetName());

    }
    public void DisplayNoMoreRounds(HumanPlayer player)
    {
        Console.WriteLine("{0} You have already rolled twice ,no more rollings are allowed in this round." +
                    " You have scored 0 points in this round",player.GetName());
    }

    public void CompRollingDicesDisplay( string name )
    {
        Console.WriteLine("{0} is rolling the dices", name);
        Thread.Sleep(3000);
        Console.WriteLine("The dices have been rolled, {0} got these values: ", name);
    }
    public void HumanRollingDicesDisplay(string name)
    {
        Console.WriteLine("{0} Please press any key to roll your dices", name);
        Console.ReadKey();
        Console.WriteLine("{0} rolling dices", name);
        Thread.Sleep(3000);
        Console.WriteLine("The dices have been rolled, those are the values you got: ");
    }
    public bool PlayerRemainingDicesDisplay()
    {
        Console.WriteLine("Please press any key to confirm the re-roll of dices or enter 'NO' to keep your dices");
        if (Console.ReadLine().ToUpper() == "NO")
        {
            return false;
        }
        return true;
    }
    
    public void CompRemainingDicesDisplay(string name)
    {
        Console.WriteLine("{0} re-rolling dices ", name);
        Thread.Sleep(3000);
    }
}


