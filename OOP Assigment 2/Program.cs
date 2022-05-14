// See https://aka.ms/new-console-template for more information
Console.WriteLine("Welcome to the Three of More Dice Game! \n");

HumanPlayer player1 = new HumanPlayer();
HumanPlayer player2 = new HumanPlayer();
HumanPlayer player3 = new HumanPlayer();
CompPlayer compPlayer = new CompPlayer();
UI userInterface = new UI();
Game game;
int input;

while (true)
{
    game = new Game();


    Console.WriteLine("Would like to play again ? Enter 'Yes' to start a new game or anything else to exit");
    if (Console.ReadLine().ToUpper() == "YES")
    {
        continue;
    }
    break;
}
Environment.Exit(0);



