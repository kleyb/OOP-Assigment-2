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
    public void GameMenu(Game game,int input)
    {
        while (true)
        {
            if (input == 1)
            {
                game.PlayPVP();
                break;
            }
            else if(input == 2)
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
                throw new InvalidSelectionException("Invalid Input / Choice, please enter a number from the menu ");
                
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
        
        if ( player == null)
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
}

