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

        public void BoardSetup()
        {
            player1.SetShips();
            player2.SetShips();
            Console.WriteLine("Board setup complete");
            Console.WriteLine("Press enter to start the game.");
            Console.ReadLine();
            Console.Clear();


        }

        public bool GameOver()
        {
            if (player1.ships.Count == 0)
            {
                Console.Clear();
                Console.WriteLine($"{player2.name} wins!");
                return true;

            }
            else if (player2.ships.Count == 0)
            {
                Console.Clear();
                Console.WriteLine($"{player1.name} wins!");
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Run()
        {
            do
            {
                player1.Fire(player2);
                player1.GetBoard();

                if (GameOver())
                {
                    break;
                }

                Console.WriteLine("Press enter to pass the turn.");
                Console.ReadLine();
                Console.Clear();

                

                player2.Fire(player1);
                player2.GetBoard();

                if (GameOver())
                {
                    break;
                }

                Console.WriteLine("Press enter to pass the turn.");
                Console.ReadLine();
                Console.Clear();


            } while (true);
        }
    }
}
