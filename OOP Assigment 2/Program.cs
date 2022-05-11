// See https://aka.ms/new-console-template for more information
Console.WriteLine("Welcome to the Three of More Dice Game! \n");

HumanPlayer player1 = new HumanPlayer();
HumanPlayer player2 = new HumanPlayer();
HumanPlayer player3 = new HumanPlayer();
CompPlayer compPlayer = new CompPlayer();
Game game;
int input;

while (true)
{
    game = new Game();
    DisplayMenu();

    while (true)
    {
        try
        {
            input = int.Parse(Console.ReadLine());
            break;
        }
        catch (Exception)
        {
            Console.WriteLine("Please enter only numbers");
        }
    }

    if (input == 1)
    {
        game.PlayPVP(player1, player2);
        game.FindWinner(player1, player2);
    }
    else if (input == 2)
    {
        game.Play3PVP(player1, player2, player3);
        game.FindWinner(player1, player2,player3);
    }
    else if (input == 3)
    {
        game.PlayVSComp(player1, compPlayer);
        game.FindWinner(player1, compPlayer);
    }
    else { Console.WriteLine("Invalid selection! \n"); continue; }


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
