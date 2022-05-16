using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//User interface handles the I/O ( input and displays)
class UI
{   // Display the menu options and takes the use input
    public void DisplayMenu(Game game)
    {   //Creates the input variable to store the user's input
        int input;

        while (true)
        {   //Display menu
            Console.WriteLine("Please select your game mode by entering it's number on the list : ");
            Console.WriteLine("1. Player VS Player");
            Console.WriteLine("2. Player VS Player VS Player");
            Console.WriteLine("3. Player vs Computer");
            Console.WriteLine("4. Exit Game");
            try
            {   // Tries to parse the input from the user into an int
                input = int.Parse(Console.ReadLine());
                // passes the 'parsed' input into the GameMenu method along with the game
                GameMenu(game, input);
                //Breaks out of the loop
                break;
            }
            // If the user enters a number that is not in the menu , then the program throws and error ( customised exception) 
            catch (InvalidSelectionException e)
            {
                // Display the exception message
                Console.WriteLine(e.Message);
            }
            //if the user enters any invalid value and its not possible to parse into an int , throws an execptions
            catch (Exception)
            {
                Console.WriteLine("Invalid input ,Please enter only numbers");
            }
            //continues the loop while there is not valid selection
        }
    }
    //The GameMethod takes the user input and selects the game mode or exist the game , if the user selects a value not in the menu
    // the method then created a new instance of the 'InvalidSelectionException' and throw the error in the 'try and catch' from the previous method
    public void GameMenu(Game game, int input)
    {
        // Takes the user input and selects the game mode from the menu , otherwise throw exception 
        if (input == 1)
        {
            game.PlayPVP();

        }
        else if (input == 2)
        {
            game.Play3PVP();

        }
        else if (input == 3)
        {
            game.PlayVSComp();

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

    // The DisplayScoreBoard displays the score board, note that this one only takes 2 parameters as this one is only used to show 
    //the game board on the game modes 'Player VS Player' and 'Player VS Computer'
    public void DisplayScoreBoard(Player player1, Player player2)
    {   // Display the score and name by using the player's GetName and GetPOints Methods
        Console.WriteLine("\n Game Score Board:");
        Console.WriteLine("{0} has {1} points", player1.GetName(), player1.GetPoints());
        Console.WriteLine("{0} has {1} points\n", player2.GetName(), player2.GetPoints());
    }
    // This DisplayScoreBoard is an overload of the previous method , the difference is in the number of parameters it takes
    // it is used at the 'Player VS Player VS Player' mode 
    public void DisplayScoreBoard(HumanPlayer player1, HumanPlayer player2, HumanPlayer player3)
    {   // Display the score and name by using the player's GetName and GetPOints Methods
        Console.WriteLine("\n Game Score Board:");
        Console.WriteLine("{0} has {1} points", player1.GetName(), player1.GetPoints());
        Console.WriteLine("{0} has {1} points", player2.GetName(), player2.GetPoints());
        Console.WriteLine("{0} has {1} points\n", player3.GetName(), player3.GetPoints());
    }
    //The DisplayWinner handles the display of the winner of the game , or if the game ended in a tie 
    public void DisplayWinner(Player player)
    {
        //if player is  null then the game ended in a tie
        if (player == null)
        {
            Console.WriteLine("The game ended in a tie! ");
        }
        else
        {   // Anything else means that there is a winner to the game
            Console.WriteLine("{0} has won the game with {1} points ", player.GetName(), player.GetPoints());
        }
    }

    //Display Dices
    public void DisplayDices(Die[] die)
    {   //For every dice in die 
        foreach (var dice in die)
        {   //Prints on the same line every dice along with a space
            Console.Write(dice.GetValueOnTop() + " ");
        }
        //Jump a line
        Console.WriteLine("\n");
    }
    //Display Dices Values using the diceValues list
    public void DisplayDices(List<int> diceValues)
    {   // for every value in the dice
        foreach (var values in diceValues)
        {   //Prints on the same line along with a space
            Console.Write(values + " ");
        }
        //Jump a line
        Console.WriteLine("\n");
    }
    // Displays the End of the game menu , shown at the end of every game , handles the input and returns a bool
    public bool EndOfGameMenu()
    {   // Declares a variable to store the user's input
        int input;
        //Display the Menu
        Console.WriteLine("Please select one of the options bellow:");
        Console.WriteLine("1. Play Again");
        Console.WriteLine("2. Exit Game");
        while (true)
        {   // Tries to parse the user's input into an int 
            try
            {   //Parses input
                input = int.Parse(Console.ReadLine());
                //if input is equal to 1 returns true , the user wants to play again
                if (input == 1)
                {
                    return true;
                }
                //if input is equal to 2 , returns false , the use doesnt wish to play again 
                else if (input == 2)
                {
                    return false;
                }
                else
                {   // if the user doesn't select a option from the menu , throws an execption 
                    throw new InvalidSelectionException("Invalid selection, please enter a number from the menu ");
                }
            }
            catch (InvalidSelectionException e)
            {   // throw the InvalidSelectionException exception and display a message
                Console.WriteLine(e.Message);
            }
            catch (Exception)
            {   // if there is an invalid input format then display the error message below
                Console.WriteLine("Please enter only numbers");
            }            
        }
    }

    //This Method Display weather a player has scored points or not in the round
    //it takes the player and the number of points
    public void DisplayPointsScored(Player player, int points)
    {   // if the number of points is 0 then the players hasn't scored in this round
        if (points == 0)
        {
            Console.WriteLine("No points scored in this round. {0} You scored 0 points", player.GetName());
        }
        else
        {   // else displayes a message with the name and ammount of points scored 
            Console.WriteLine("{0} scored {1} points! ", player.GetName(), points);
        }
    }
    //The SelectDicesToKeep method is used to display and take the input of the user , the use has to decide which 'two of-a-kind' he wants to keep
    public int SelectDicesToKeep(List<int> temp)
    {   //varible to store the user's choice
        int choice;
        // Displays a message to explain to the user what has happened and what is needed of him
        Console.WriteLine("You have not scored any points at this round, however you have 2 of-a-kind twice " +
                    "this allows you to roll the dices again, please choose which '2 of-a-kind' would you like to keep");
        //While loop is used to keep the questions being asked
        while (true)
        {   //Request the user to input his choice
            Console.WriteLine("Please enter '1' to keep {0} or enter '2' to keep {1}: ", temp[0], temp[1]);
            // Tries to parse the user input
            try
            {   //parses to Choice the 'parsed' input
                choice = int.Parse(Console.ReadLine());
                //if 
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
            catch (InvalidSelectionException e)
            {   // throw the InvalidSelectionException exception and display a message
                Console.WriteLine(e.Message);
            }
            catch (Exception)
            {   // if there is an invalid input format then display the error message below
                Console.WriteLine("Please enter only numbers");
            }
        }
    }
    // The SetPlayersName is used to request a name for the player
    public void SetPlayersName(HumanPlayer player)
    {   //Request a name for the player
        Console.WriteLine("Please enter the name of the Player \n");
        //Declared the variable name as a empty.string
        string name = string.Empty;
        // While name is null or empty or a white space , continues the loop
        while (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
        {   // Resquest the user to input the name
            Console.WriteLine("Please enter your name: ");
            //Assignts the user's input into the name variable
            name = Console.ReadLine();
        }
        // user the SetName method of players class to set the name by passing the value at the 'name' variable
        player.SetName(name);
    }
    // Defines the name of the Computer Player
    public void SetPlayersName(CompPlayer compPlayer)
    {
        //Computer player doesn't need an input , its name is defined by the computer as 'Computer Player'
        compPlayer.SetName("Computer Player");
    }
    // DisplayNextRoundMessage is used to warn the user that a new round is about to start 
    public void DisplayNextRoundMessage()
    {   // Ask for an input to start next round
        Console.WriteLine("Please press any key to start next round");
        //Waits for a key input
        Console.ReadKey();
        //Displays the message then waits 3 seconds, the Thread.Sleep(n) is used to make program wait for a n of milliseconds 
        Console.WriteLine("Next round starting...");
        Thread.Sleep(3000);
        //Clear the console screen
        Console.Clear();
    }
    // The DisplayNoMoreRounds is used to display to the console that the computer player has reached the rounds limit of 2
    public void DisplayNoMoreRounds(CompPlayer compPlayer)
    {
        Console.WriteLine("{0} has re-rolled the dices 2 times , no more rollings allowed in this round", compPlayer.GetName());

    }
    //This DisplayNoMoreRounds is an overload of the previous method which takes the Human player instead of Computer player and displays a different message
    public void DisplayNoMoreRounds(HumanPlayer player)
    {
        Console.WriteLine("{0} You have already rolled twice ,no more rollings are allowed in this round." +
                    " You have scored 0 points in this round",player.GetName());
    }
    // The method CompRollingDicesDisplay display to the console what the Computer player is currently doing 
    public void CompRollingDicesDisplay( string name )
    {
        Console.WriteLine("{0} is rolling the dices", name);
        Thread.Sleep(3000);
        Console.WriteLine("The dices have been rolled, {0} got these values: ", name);
    }
    // The HumanRollingDicesDisplay ask the user for an input to re-roll his dices 
    public void HumanRollingDicesDisplay(string name)
    {
        Console.WriteLine("{0} Please press any key to roll your dices", name);
        //waits for a key input
        Console.ReadKey();
        Console.WriteLine("{0} rolling dices", name);
        //waits 3 seconds
        Thread.Sleep(3000);
        Console.WriteLine("The dices have been rolled, those are the values you got: ");
    }
    // The PlayerRemainingDicesDisplay gets a confirmation from the user that he wants to re-roll his dices
    public bool PlayerRemainingDicesDisplay()
    {   // Request selection
        Console.WriteLine("Please press any key to confirm the re-roll of dices or enter 'NO' to keep your dices");
        if (Console.ReadLine().ToUpper() == "NO")
        {   // if user enters 'No' , returns false 
            return false;
        }
        // Return true if the user enters any other input
        return true;
    }
    //This method simply displays on the console what is being done by that Computer Player
    public void CompRemainingDicesDisplay(string name)
    {
        Console.WriteLine("{0} re-rolling dices ", name);
        Thread.Sleep(3000);
    }
}


