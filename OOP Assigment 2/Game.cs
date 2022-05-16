using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Game
{
    HumanPlayer player1 = new HumanPlayer();
    HumanPlayer player2 = new HumanPlayer();
    HumanPlayer player3 = new HumanPlayer();
    CompPlayer compPlayer = new CompPlayer();
    private Die[] die = new Die[5];
    UI userInterface = new UI();
    
    

    public void ResetAttemptsNumber(HumanPlayer player1, HumanPlayer player2, HumanPlayer player3)
    {
        player1.SetAttempts(2);
        player2.SetAttempts(2);
        player3.SetAttempts(2);
    }

    public void ResetAttemptsNumber(Player player1,Player player2)
    {        
        player1.SetAttempts(2);
        player2.SetAttempts(2);
    }

    // Player vs Player
    public void PlayPVP()
    {
        Console.Clear();
        userInterface.SetPlayersName(player1);
        userInterface.SetPlayersName(player2);

        while (true)
        {
            CheckforNumbers(player1.PlayDices(die,userInterface), player1);
            CheckforNumbers(player2.PlayDices(die,userInterface), player2);
            ResetAttemptsNumber(player1, player2);
            userInterface.DisplayScoreBoard(player1,player2);
            if (player1.GetPoints() >= 10 || player2.GetPoints() >= 10)
            {
                userInterface.DisplayWinner(FindWinner(player1, player2));
                break;
            }
            userInterface.DisplayNextRoundMessage();
        }   
    }
    //Player vs Player vs Player 
    public void Play3PVP ()
    {
        Console.Clear();

        userInterface.SetPlayersName(player1);
        userInterface.SetPlayersName(player2);
        userInterface.SetPlayersName(player3);

        while (true)
        {
            CheckforNumbers(player1.PlayDices(die,userInterface), player1);
            CheckforNumbers(player2.PlayDices(die,userInterface), player2);
            CheckforNumbers(player3.PlayDices(die,userInterface), player3);
            ResetAttemptsNumber(player1,player2,player3);

            userInterface.DisplayScoreBoard(player1, player2,player3);
            if (player1.GetPoints() >= 10 || player2.GetPoints() >= 10 || player3.GetPoints() >= 10)
            {
                userInterface.DisplayWinner(FindWinner(player1, player2,player3));
                break;
            }
            userInterface.DisplayNextRoundMessage();

        }
    }
    //Player vs Computer Player
    public void PlayVSComp()
    {
        Console.Clear();

        userInterface.SetPlayersName(player1);
        userInterface.SetPlayersName(compPlayer);

        while (true)
        {
            CheckforNumbers(player1.PlayDices(die,userInterface), player1);
            CheckforNumbers(compPlayer.PlayDices(die,userInterface), compPlayer);

            ResetAttemptsNumber(player1, compPlayer);
            userInterface.DisplayScoreBoard(player1, compPlayer);

            if (player1.GetPoints() >= 10 || compPlayer.GetPoints() >= 10)
            {
                userInterface.DisplayWinner(FindWinner(player1, compPlayer)); 
                break;
            }
            userInterface.DisplayNextRoundMessage();

        }
    }

    public void CheckforNumbers(List<int> diceValues, HumanPlayer player)
    {
        Dictionary<int,int> frequency = new Dictionary<int,int>();
        List<int> temp = new List<int>();
        int pairToKeep =0;
        bool scored = false;

        foreach (int i in diceValues)
        {
            if (!frequency.ContainsKey(i))
            {
                frequency.Add(i, 1);
            }
            else
            {
                frequency[i]++;
            }
        }
        foreach (int i in frequency.Keys)
        {
            if (frequency[i] >= 2)
            {
                if (frequency[i] >= 3)
                {
                    if (frequency[i] == 3)
                    {
                        userInterface.DisplayPointsScored(player, 3);
                        player.SetPoints(3);
                    }
                    else if (frequency[i] == 4)
                    {
                        userInterface.DisplayPointsScored(player, 6);
                        player.SetPoints(6);
                    }
                    else if (frequency[i] == 5)
                    {
                        userInterface.DisplayPointsScored(player, 12);
                        player.SetPoints(12);
                    }
                    scored = true;
                    break;
                }
                temp.Add(i);
                pairToKeep = i;
            }
        }

        if (temp.Any() && scored == false)
        {
            if (temp.Count > 1 && player.GetAttempts() < 0)
            {
                pairToKeep = userInterface.SelectDicesToKeep(temp);
            }

            diceValues = player.PlayRemainingDices(userInterface,die,diceValues, pairToKeep);
            if (diceValues.Count <= 0)
            {                
                userInterface.DisplayNoMoreRounds(player);
                player.SetPoints(0);
            }
            else
            {
                userInterface.DisplayDices(die);
                CheckforNumbers(diceValues, player);
            }
        }
        else if(!temp.Any() && scored == false)
        {
            userInterface.DisplayPointsScored(player, 0);
        }
    }

    public void CheckforNumbers(List<int> diceValues, CompPlayer compPlayer)
    {
        //Dictionary is used to determine the frequency of numbers and used to find out if there is a 2 of-a-kind twice 
        Dictionary<int, int> frequency = new Dictionary<int, int>();
        List<int> temp = new List<int>();
        int pairToKeep = 0;
        bool scored = false;

        foreach (int i in diceValues)
        {
            if (!frequency.ContainsKey(i))
            {
                frequency.Add(i, 1);
            }
            else
            {
                frequency[i]++;
            }
        }
        foreach (int i in frequency.Keys)
        {
            if (frequency[i] >= 2)
            {
                if (frequency[i] >= 3)
                {
                    if (frequency[i] == 3)
                    {
                        userInterface.DisplayPointsScored(compPlayer, 3);
                        compPlayer.SetPoints(3);
                    }
                    else if (frequency[i] == 4)
                    {
                        userInterface.DisplayPointsScored(compPlayer, 6);
                        compPlayer.SetPoints(6);
                    }
                    else if (frequency[i] == 5)
                    {
                        userInterface.DisplayPointsScored(compPlayer, 12);
                        compPlayer.SetPoints(12);
                    }
                    scored = true;
                    break;
                }
                temp.Add(i);
                pairToKeep = i;
            }
        }

        if (temp.Any() && scored == false)
        {
            if (temp.Count > 1)
            {
                pairToKeep = temp.First();
            }

            diceValues = compPlayer.PlayRemainingDices(userInterface,die,diceValues, pairToKeep);
            if (diceValues.Count <= 0)
            {
                userInterface.DisplayNoMoreRounds(compPlayer);
                compPlayer.SetPoints(0);
            }
            else
            {
                userInterface.DisplayDices(diceValues);
                CheckforNumbers(diceValues, compPlayer);
            }
        }
        else if (!temp.Any() && scored == false)
        {
            userInterface.DisplayPointsScored(compPlayer, 0);
        }
    }

    public Player FindWinner(Player player1, Player player2)
    {        
        if (player1.GetPoints() > player2.GetPoints())
        {
            return player1;
        }
        else if (player1.GetPoints() < player2.GetPoints())
        {
            return player2;
        }
        else
        {   //returns null if there is no clear winner 
            return null;
        }
    }
    public Player FindWinner(HumanPlayer player1, HumanPlayer player2, HumanPlayer player3)
    {
        if (player1.GetPoints() > player2.GetPoints() && player1.GetPoints() > player3.GetPoints())
        {
            return player1;
        }
        else if (player1.GetPoints() < player2.GetPoints() && player3.GetPoints() < player2.GetPoints())
        {
            return player2;
        }
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

