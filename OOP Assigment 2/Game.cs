using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class Game
{
    Player player1 = new Player();
    Player player2 = new Player();
    public void DisplayScoreBoard()
    {
        Console.WriteLine("Game Board Score:");
        Console.WriteLine("Player 1 has {0) points",player1.GetPoints());
        Console.WriteLine("Player 2 has {0) points",player2.GetPoints());

    }
    // Player vs Player
    public void PlayPVP()
    {
        

        while ( player1.GetPoints() < 50 || player2.GetPoints() < 50)
        {
            CheckforNumbers(player1.PlayDice(), player1);
            CheckforNumbers(player2.PlayDice(), player2);

            DisplayScoreBoard();
        }
        

    }
    public void CheckforNumbers(List<int> diceValues, Player player)
    {
        for (int i = 1; i < 7; i++)
        {
            int[] a = diceValues.FindAll(element => element.Equals(i)).ToArray();
            if (a.Length >= 2)
            {
                if( a.Length >= 3)
                {
                    if (a.Length == 3)
                    {
                        player.SetPoints(3);
                    }
                    else if (a.Length == 4)
                    {
                        player.SetPoints(6);
                    }
                    else if (a.Length == 5)
                    {
                        player.SetPoints(12);
                    }
                    break;                    
                }
                CheckforNumbers(player.PlayDice(), player);
                break;
            }
        }
    }
}

