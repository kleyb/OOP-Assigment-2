using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class UI
{
    public int DisplayMenu()
    {
        int input;
        Console.WriteLine("Please select your game mode by entering it's number on the list : ");
        Console.WriteLine("1. Player VS Player");
        Console.WriteLine("2. Player VS Player VS Player");
        Console.WriteLine("3. Player vs Comp");

        while (true)
        {
            try
            {
                return input = int.Parse(Console.ReadLine());                
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter only numbers");
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

    public void DisplayEndingText()
    {

        Console.WriteLine("Would like to play again ? Enter '1' to start a new game or anything else to exit");
        if (int.Parse(Console.ReadLine()) == 1)
        {
            
        }

}

