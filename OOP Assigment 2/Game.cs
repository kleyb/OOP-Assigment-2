using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Game
{   // Creates and instance of all players, of die and of UI
    HumanPlayer player1 = new HumanPlayer();
    HumanPlayer player2 = new HumanPlayer();
    HumanPlayer player3 = new HumanPlayer();
    CompPlayer compPlayer = new CompPlayer();
    private Die[] die = new Die[5];
    UI userInterface = new UI();  
    //Resets the number of attempts , this method works on the game mode 'Player vs Player vs Player'
    public void ResetAttemptsNumber(HumanPlayer player1, HumanPlayer player2, HumanPlayer player3)
    {
        player1.SetAttempts(2);
        player2.SetAttempts(2);
        player3.SetAttempts(2);
    }
    //This method , like the one previous , also resets the number of attempts , it is an overload and it works with
    //The 'PVP' mode and ' Player vs Computer'
    public void ResetAttemptsNumber(Player player1,Player player2)
    {        
        player1.SetAttempts(2);
        player2.SetAttempts(2);
    }

    //Plays the Player vs Player mode
    public void PlayPVP()
    {   // Starts by clearing the console screen and seeting up the players' names
        Console.Clear();
        userInterface.SetPlayersName(player1);
        userInterface.SetPlayersName(player2);
        // While both players' scored are lower equal to 50
        while (player1.GetPoints() <= 50 && player2.GetPoints() <= 50)
        {   // Plays the dices and then passes the result into CheckForNumbers
            CheckforNumbers(player1.PlayDices(die,userInterface), player1);
            CheckforNumbers(player2.PlayDices(die,userInterface), player2);
            //Resets the number of attempts
            ResetAttemptsNumber(player1, player2);
            //Displays the score board
            userInterface.DisplayScoreBoard(player1,player2);
            //Checks if there is a winner
            if (player1.GetPoints() >= 50 || player2.GetPoints() >= 50)
            {
                //if any or both of the players' point are greater than 50 , finds the winner and breaks the loop
                userInterface.DisplayWinner(FindWinner(player1, player2));
                break;
            }
            //Displays the end of game menu and allows the users to decide to play again or exit the game
            userInterface.DisplayNextRoundMessage();
        }   
    }
    //Player vs Player vs Player 
    public void Play3PVP ()
    {   // Starts by clearing the console screen and seeting up the players' names
        Console.Clear();
        userInterface.SetPlayersName(player1);
        userInterface.SetPlayersName(player2);
        userInterface.SetPlayersName(player3);
        // While all 3 players' scored are lower or equal to 50
        while (player1.GetPoints() <= 50 && player2.GetPoints() <= 50 && player3.GetPoints() <= 50)
        {// Plays the dices and then passes the result into CheckForNumbers
            CheckforNumbers(player1.PlayDices(die,userInterface), player1);
            CheckforNumbers(player2.PlayDices(die,userInterface), player2);
            CheckforNumbers(player3.PlayDices(die,userInterface), player3);
            //Resets the number of attempts
            ResetAttemptsNumber(player1,player2,player3);
            //Displays the score board
            userInterface.DisplayScoreBoard(player1, player2,player3);
            //Check if there is a winner
            if (player1.GetPoints() >= 50 || player2.GetPoints() >= 50 || player3.GetPoints() >= 50)
            {   //if any or all of the players' point are greater than 50 , finds the winner and breaks the loop
                userInterface.DisplayWinner(FindWinner(player1, player2,player3));
                break;
            }
            //Displays the end of game menu and allows the users to decide to play again or exit the game
            userInterface.DisplayNextRoundMessage();
        }
    }
    //Player vs Computer Player
    public void PlayVSComp()
    {   // Starts by clearing the console screen and seeting up the player name, the compPlayer's name is already pre-defined
        Console.Clear();
        userInterface.SetPlayersName(player1);
        userInterface.SetPlayersName(compPlayer);
        // While both players' scored are lower equal to 50
        while (player1.GetPoints() <= 50 && compPlayer.GetPoints() <= 50)
        {   // Plays the dices and then passes the result into CheckForNumbers
            CheckforNumbers(player1.PlayDices(die,userInterface), player1);
            CheckforNumbers(compPlayer.PlayDices(die,userInterface), compPlayer);
            //Resets the number of attempts
            ResetAttemptsNumber(player1, compPlayer);
            //Displays score board
            userInterface.DisplayScoreBoard(player1, compPlayer);
            //Check if there is a winner
            if (player1.GetPoints() >= 50 || compPlayer.GetPoints() >= 50)
            {   //if any or both of the players' point are greater than 50 , finds the winner and breaks the loop
                userInterface.DisplayWinner(FindWinner(player1, compPlayer)); 
                break;
            }
            //Displays the end of game menu and allows the user to decide to play again or exit the game
            userInterface.DisplayNextRoundMessage();
        }
    }
    //Checks for Numbers on for Human players
    public void CheckforNumbers(List<int> diceValues, HumanPlayer player)
    {   //Create a dictionary to find the frequency of numbers
        Dictionary<int,int> frequency = new Dictionary<int,int>();
        //Temporary list to store the 2 of-a-kind
        List<int> temp = new List<int>();
        // the pair to keep variable to store the 2 of-a-kind choosen by the user
        int pairToKeep =0;
        //Bool to find out if the user scored
        bool scored = false;

        //add the keys and frequency number into the dictionary
        foreach (int i in diceValues)
        {   //if key not in dictionary create one and adds 1 as value
            if (!frequency.ContainsKey(i))
            {
                frequency.Add(i, 1);
            }
            else // if contains the key adds 1 to value
            {
                frequency[i]++;
            }
        }
        //iterates through the keys
        foreach (int i in frequency.Keys)
        {   //checks the value of the key, if greater of equal to 2
            if (frequency[i] >= 2)
            {   //if equal or greater than 3
                if (frequency[i] >= 3)
                {   //if equal to 3 displays the user scored and adds 3 into the player's points
                    if (frequency[i] == 3)
                    {
                        userInterface.DisplayPointsScored(player, 3);
                        player.SetPoints(3);
                    }
                    //if equal to 4 displays the user scored and adds 6 into the player's points
                    else if (frequency[i] == 4) 
                    {
                        userInterface.DisplayPointsScored(player, 6);
                        player.SetPoints(6);
                    }
                    //if equal to 5 displays the user scored and adds 12 into the player's points
                    else if (frequency[i] == 5)
                    {
                        userInterface.DisplayPointsScored(player, 12);
                        player.SetPoints(12);
                    }
                    //if the value is equal or greater to 3 then the player scoreed, make scored true and break
                    scored = true;
                    break;
                }
                //if there is a 2 of-a-kind adds into list
                temp.Add(i);
                //sets the last value of a 2 of-a-kind into pairToKeep,
                //this is so if there only one '2 of-a-kind' the player re-rolls the dices but keeps the value on the variable
                pairToKeep = i;
            }
        }
        //if temp has any values and the player hasn't scored
        if (temp.Any() && scored == false)
        {   // if there are more than 1 '2 of-a-kind' then the user needs to select one to keep
            if (temp.Count > 1 && player.GetAttempts() < 0)
            {   //User the 'SelectDicesToKeep' from interface to get the input from player
                pairToKeep = userInterface.SelectDicesToKeep(temp);
            }
            //Re-rolls the dices 
            diceValues = player.PlayRemainingDices(userInterface,die,diceValues, pairToKeep);
            if (diceValues.Count <= 0) // if diceValues has no values
            {   //displays to the player a message and set his points to 0            
                userInterface.DisplayNoMoreRounds(player);
                player.SetPoints(0);
            }
            else
            {   //displays the new dice values to the player and recursively calls the method with the new values
                userInterface.DisplayDices(die);
                CheckforNumbers(diceValues, player);
            }
        }// if temp has no values and the player hasn't scored
        else if(!temp.Any() && scored == false)
        {   //then the player scored 0 points
            userInterface.DisplayPointsScored(player, 0);
        }
    }
    //Checks the numbers for compPlayer
    public void CheckforNumbers(List<int> diceValues, CompPlayer compPlayer)
    {
        //Dictionary is used to determine the frequency of numbers and used to find out if there is a 2 of-a-kind twice 
        Dictionary<int, int> frequency = new Dictionary<int, int>();
        //Temporary list to store the 2 of-a-kind
        List<int> temp = new List<int>();
        // the pair to keep variable to store the 2 of-a-kind choosen by the user
        int pairToKeep = 0;
        //Bool to find out if the user scored
        bool scored = false;

        //add the keys and frequency number into the dictionary
        foreach (int i in diceValues)
        {   //if key not in dictionary create one and adds 1 as value
            if (!frequency.ContainsKey(i))
            {
                frequency.Add(i, 1);
            }
            else// if contains the key adds 1 to value
            {
                frequency[i]++;
            }
        }
        //iterates through the keys
        foreach (int i in frequency.Keys)
        {   //checks the value of the key, if greater of equal to 2
            if (frequency[i] >= 2)
            {    //if equal or greater than 3
                if (frequency[i] >= 3)
                {   //if equal to 3 displays the compPlayer scored , adds 3 into the compPlayer's points
                    if (frequency[i] == 3)
                    {
                        userInterface.DisplayPointsScored(compPlayer, 3);
                        compPlayer.SetPoints(3);
                    }
                    //if equal to 4 displays the compPlayer scored , adds 6 into the compPlayer's points
                    else if (frequency[i] == 4)
                    {
                        userInterface.DisplayPointsScored(compPlayer, 6);
                        compPlayer.SetPoints(6);
                    }
                    //if equal to 5 displays the compPlayer scored , adds 12 into the compPlayer's points
                    else if (frequency[i] == 5)
                    {
                        userInterface.DisplayPointsScored(compPlayer, 12);
                        compPlayer.SetPoints(12);
                    }
                    //if the value is equal or greater to 3 then the compPlayer scored, make scored true and breaks the loop
                    scored = true;
                    break;
                }
                //if there is a 2 of-a-kind adds into list
                temp.Add(i);
                //sets the last value of a 2 of-a-kind into pairToKeep,
                pairToKeep = i;
            }
        }
        //if temp has any values and the compPlayer hasn't scored
        if (temp.Any() && scored == false)
        {   // if there are more than 1 '2 of-a-kind' then the compPlayer selects the first
            if (temp.Count > 1)
            {   //assigns the first value of temp
                pairToKeep = temp.First();
            }
            //re-rolls the dices
            diceValues = compPlayer.PlayRemainingDices(userInterface,die,diceValues, pairToKeep);
            if (diceValues.Count <= 0) //if diceValues has no values
            {   //displays to the console a message and set his points to 0 
                userInterface.DisplayNoMoreRounds(compPlayer);
                compPlayer.SetPoints(0);
            }
            else
            {   //displays the new dice values to the console and recursively calls the method with the new values
                userInterface.DisplayDices(diceValues);
                CheckforNumbers(diceValues, compPlayer);
            }
        }// if temp has no values and compPlayer hasn't scored
        else if (!temp.Any() && scored == false)
        {   //CompPlayer scored 0 points
            userInterface.DisplayPointsScored(compPlayer, 0);
        }
    }
    //Find the winner for game modes with 2 players
    public Player FindWinner(Player player1, Player player2)
    {   //if player1's points are greater than player2 , return player1     
        if (player1.GetPoints() > player2.GetPoints())
        {
            return player1;
        }
        //if player2's points are greater than player1 , return player2
        else if (player1.GetPoints() < player2.GetPoints())
        {
            return player2;
        }
        else
        {   //returns null if there is no clear winner 
            return null;
        }
    }
    //Find the winner for the game mode with 3 players
    public Player FindWinner(HumanPlayer player1, HumanPlayer player2, HumanPlayer player3)
    {   //if player1's points are greater than player2's points and player3's points , return player1
        if (player1.GetPoints() > player2.GetPoints() && player1.GetPoints() > player3.GetPoints())
        {
            return player1;
        }
        //if player2's points are greater than player1's points and player3's points , return player2
        else if (player1.GetPoints() < player2.GetPoints() && player3.GetPoints() < player2.GetPoints())
        {
            return player2;
        }
        //if player3's points are greater than player1's points and player2's points , return player3
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

