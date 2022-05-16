// Created by Kleybson Sousa on 15/05/2022 , using Visual Studio 2022 , C# 10 .NET 6.0

// Welcome message to the user(s) at the start of the game
Console.WriteLine("Welcome to the Three Or More Dice Game! \n");

// Created a new instance of the UI class 
UI userInterface = new UI();
// Creates a new instance of the Game class but doesn't initialize it 
Game game;

while (true)
{   //initializes inside the loop , by doing this I made sure that every time the loop is started, a different game is played
    game = new Game();
    // Displays the Menu and plays the game
    userInterface.DisplayMenu(game);
    // at the end of the game uses the 'EndOfGameMenu' to ask if the use wants to play again
    //the method will return true if the user wants to play again
    if (userInterface.EndOfGameMenu())
    {   // Cleans the screen and re-starts the loop
        Console.Clear();
        continue;
    }
    //else breaks the loop
    break;
}
// Closes the program 'Gracefully'
Environment.Exit(0);



