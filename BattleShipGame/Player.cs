using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame
{
    class Player
    {
        public Board playerBoard = new Board();
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


    }
    
}
