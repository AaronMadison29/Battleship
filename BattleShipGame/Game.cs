using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BattleShipGame
{
    class Game
    {
        Player player1;
        Player player2;
        Regex playerIntput = new Regex("[0-2]");
        Random ran = new Random();

        public Game()
        {
          
        }

        public int PlayerChoice()
        {
            Console.WriteLine("How many players are there? 0, 1, or 2:");

            string input = Console.ReadLine();
            int players;

            if(playerIntput.IsMatch(input))
            {
                players = Convert.ToInt32(input);
            }
            else
            {
                Console.WriteLine("Please enter a valid input.");
                PlayerChoice();
                return 0;
            }

            return players;
        }

        public void SetPlayers(int players)
        {
            switch(players)
            {
                case 0:
                    player1 = new Computer(1, ran);
                    player2 = new Computer(2, ran);
                    break;
                case 1:
                    player1 = new Human();
                    player1.SetName();
                    player2 = new Computer(1, ran);
                    break;
                case 2:
                    player1 = new Human();
                    player1.SetName();
                    player2 = new Human();
                    player2.SetName();
                    break;
            }
        }

        public void BoardSetup(int players)
        {
            player1.SetShips();
            player2.SetShips();
            if(players == 0)
            {
                player1.GetBoard();
                player2.GetBoard();
            }
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

                Console.Write("Press enter to pass the turn.");
                Console.ReadLine();
                Console.Clear();

                

                player2.Fire(player1);
                player2.GetBoard();

                if (GameOver())
                {
                    break;
                }

                Console.Write("Press enter to pass the turn.");
                Console.ReadLine();
                Console.Clear();


            } while (true);
        }
    }
}
