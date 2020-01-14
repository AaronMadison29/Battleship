using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame
{
    class Game
    {
        Player player1;
        Player player2;

        public Game(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;

        }

        public void Run()
        {
            //player1.SetShips();
            //player2.SetShips();
            //Console.WriteLine("Board setup complete");

            Console.WriteLine("Player1 board:");
            Console.Write("    (1)(2)(3)(4)(5)(6)(7)(8)(9)(10)\n");
            for (int i = 0; i < 10; i++)
            {
                if(i < 9)
                {
                    Console.Write(" (" + (i + 1) + ")");
                }
                else
                {
                    Console.Write("(" + (i + 1) + ")");
                }
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(player1.playerBoard.board[j, i]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Player2 board:");
            Console.Write("    (1)(2)(3)(4)(5)(6)(7)(8)(9)(10)\n");
            for (int i = 0; i < 10; i++)
            {
                if (i < 9)
                {
                    Console.Write(" (" + (i + 1) + ")");
                }
                else
                {
                    Console.Write("(" + (i + 1) + ")");
                }
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(player2.playerBoard.board[j, i]);
                }
                Console.WriteLine();
            }
        }
    }
}
