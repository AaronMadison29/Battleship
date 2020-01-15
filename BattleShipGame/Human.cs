using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BattleShipGame
{
    class Human : Player
    {

        public Regex coordInput = new Regex(@"\d\d?\,\d\d?");
        public Human()
        {

        }
        public override void SetShips()
        {
            Console.Clear();
            Console.WriteLine("Begin setup for " + name);
            foreach (Ship ship in ships)
            {
                ship.Place(playerBoard);
                for (int i = 1; i <= 10; i++)
                {
                    for (int j = 1; j <= 10; j++)
                    {
                        Console.Write(playerBoard.board[j - 1, i - 1]);
                    }
                    Console.WriteLine();
                }
            }
            Console.Clear();
        }
        
        public override void Fire(Player opponent)
        {
            GetOpponentBoard();

            Console.WriteLine($"{name}, what coordinates would you like to fire at?(X/Y)");
            string input = Console.ReadLine();
            string[] array;
            if (coordInput.IsMatch(input))
            {
                array = input.Split(',');
            }
            else
            {
                Console.WriteLine("Please enter a valid coordinate set.");
                Fire(opponent);
                return;
            }

            int x = Convert.ToInt32(array[0]) - 1;
            int y = Convert.ToInt32(array[1]) - 1;

            if (opponent.playerBoard.board[x, y] == "[ ]")
            {
                Console.WriteLine("Sploosh\n");
                opponent.playerBoard.board[x, y] = "[M]";
                opponentBoard.board[x, y] = "[M]";
            }
            else if (opponent.playerBoard.board[x, y] == "[M]")
            {
                Console.WriteLine("You've already missed at that location.");
                Fire(opponent);
                return;
            }
            else if (opponent.playerBoard.board[x, y] == "[H]")
            {
                Console.WriteLine("You've already hit at that location.");
                Fire(opponent);
                return;
            }
            else
            {
                Console.WriteLine("HUHHA!\n");
                opponent.SetDamage(opponent.playerBoard.board[x, y], this, (x, y));
            }
        }
    }
}
