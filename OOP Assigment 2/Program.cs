// See https://aka.ms/new-console-template for more information
Console.WriteLine("Welcome to the Three of More Dice Game! \n");

UI userInterface = new UI();
Game game;

while (true)
{
    game = new Game();
    userInterface.DisplayMenu(game);

    if (userInterface.EndOfGameMenu())
    {
        Console.Clear();
        continue;
    }
    break;
}
Environment.Exit(0);



