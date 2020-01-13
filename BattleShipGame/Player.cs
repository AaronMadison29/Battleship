using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame
{
    class Player
    {
        Board playerBoard = new Board();
        List<Ship> ships = new List<Ship>();

        public Player()
        {
            Destroyer destroyer = new Destroyer();
            Submarine submarine = new Submarine();
            Battleship battleship = new Battleship();
            AircraftCarrier aircraftCarrier = new AircraftCarrier();


            ships.Add(destroyer);
            ships.Add(submarine);
            ships.Add(battleship);
            ships.Add(aircraftCarrier);

        }

        public void SetShips()
        {
            foreach(Ship ship in ships)
            {
                ship.Place(playerBoard);
                foreach ((int, int) coords in ship.coordinates)
                {
                    Console.WriteLine(coords.Item1 + ", " + coords.Item2);
                }
                for(int i = 0;i < 20; i++)
                {
                    for(int j = 0; j < 20; j++)
                    {
                        Console.Write(playerBoard.board[i, j]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
    
}
