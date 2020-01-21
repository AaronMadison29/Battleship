using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BattleShipGame
{
    abstract class Player
    {
        public string name;
        public Board playerBoard = new Board();
        public Board opponentBoard = new Board();
        public List<Ship> ships = new List<Ship>();
        public Destroyer destroyer;
        public Submarine submarine;
        public Battleship battleship;
        public AircraftCarrier aircraftCarrier;

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

        public abstract void SetShips();

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

        public abstract void Fire(Player opponent);

        public void SetName()
        {
            if (name == null)
            {
                Console.WriteLine("What is your name?");
                name = Console.ReadLine();
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
                    ship.Sink(this, opponent);
                    RemoveShip(ship);
                    break;
                }
            }
        }

        public void RemoveShip(Ship ship)
        {
            ships.Remove(ship);
        }
    }
}
