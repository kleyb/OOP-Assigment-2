// See https://aka.ms/new-console-template for more information
Console.WriteLine("Welcome to the Three of More Dice Game! \n");

Game game;
string input;

while (true)
{   game = new Game();
    DisplayMenu();
    input = Console.ReadLine();
    if (input == "1")
    {
        game.PlayPVP();
    }
    else if (input == "2")
    {

    }
    else if (input == "3")
    {

    }
    else { Console.WriteLine("Please select your game mode"); }

    Console.WriteLine("Would like to play again ? Enter 'Yes' to start a new game or anything else to exit");
    if (Console.ReadLine().ToUpper() == "YES")
    {
        continue;
    }
    break;
}
Environment.Exit(0);


void DisplayMenu()
{
    Console.WriteLine("Please select your game mode by entering it's number on the list : ");
    Console.WriteLine("1. Player VS Player");
    Console.WriteLine("2. Player VS Player VS Player");
    Console.WriteLine("3. Player vs Comp");
}