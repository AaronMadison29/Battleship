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
                do
                {
                    ship.Place(playerBoard);
                    foreach ((int, int) coords in ship.coordinates)
                    {
                        Console.WriteLine(coords.Item1 + ", " + coords.Item2);
                    }
                    break;
                } while (true);
            }
        }
    }
    
}
