using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame
{
    class Player
    {
        public string name;
        public Board playerBoard = new Board();
        public Board opponentBoard = new Board();
        List<Ship> ships = new List<Ship>();
        Destroyer destroyer;
        Submarine submarine;
        Battleship battleship;
        AircraftCarrier aircraftCarrier;

        public Player()
        {
            destroyer = new Destroyer();
            submarine = new Submarine();
            battleship = new Battleship();
            aircraftCarrier = new AircraftCarrier();


            ships.Add(destroyer);
            ships.Add(submarine);
            ships.Add(battleship);
            ships.Add(aircraftCarrier);
        }

        public void SetShips()
        {
            Console.Clear();
            Console.WriteLine("Begin setup for " + name);
            foreach(Ship ship in ships)
            {
                ship.Place(playerBoard);
                for(int i = 1;i <= 10; i++)
                {
                    for(int j = 1; j <= 10; j++)
                    {
                        Console.Write(playerBoard.board[j-1, i-1]);
                    }
                    Console.WriteLine();
                }
            }
            Console.Clear();
        }

        public void GetBoard()
        {
            Console.WriteLine($"{name}'s board:");
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
                    Console.Write(playerBoard.board[j, i]);
                }
                Console.WriteLine();
            }
        }

        public void GetOpponentBoard()
        {
            Console.WriteLine("Your opponent's board:");
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
                    Console.Write(opponentBoard.board[j, i]);
                }
                Console.WriteLine();
            }
        }

        public void SetName()
        {
            Console.WriteLine("What is your name?");
            name = Console.ReadLine();
        }

        public void Fire(Player opponent)
        {
            GetOpponentBoard();

            Console.WriteLine($"{name}, what coordinates would you like to fire at?(X/Y)");
            string[] input = Console.ReadLine().Split(',');
            int x;
            int y;
            try
            {
                x = Convert.ToInt32(input[0]) - 1;
                y = Convert.ToInt32(input[1]) - 1;
            }
            catch (Exception)
            {
                Fire(opponent);
                return;
            }

            if (opponent.playerBoard.board[x, y] == "[ ]")
            {
                Console.WriteLine("Sploosh\n");
                opponent.playerBoard.board[x, y] = "[M]";
                opponentBoard.board[x, y] = "[M]";
            }
            else if(opponent.playerBoard.board[x, y] == "[M]")
            {
                Console.WriteLine("You've already missed at that location.");
                Fire(opponent);
                return;
            }
            else if(opponent.playerBoard.board[x, y] == "[H]")
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

        public void SetDamage(string boatIndentifier, Player opponent, (int, int) coord)
        {

            playerBoard.board[coord.Item1, coord.Item2] = "[H]";
            opponent.opponentBoard.board[coord.Item1, coord.Item2] = "[H]";

            switch (boatIndentifier)
            {
                case "[D]":
                    destroyer.health--;
                    break;
                case "[S]":
                    submarine.health--;
                    break;
                case "[B]":
                    battleship.health--;
                    break;
                case "[A]":
                    aircraftCarrier.health--;
                    break;
                default:
                    break;
            }

            foreach(Ship ship in ships)
            {
                if(ship.boatIndentifier == boatIndentifier && ship.health == 0)
                {
                    ship.Sink(this);
                }
            }
        }
    }
}
