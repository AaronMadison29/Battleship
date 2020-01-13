using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame
{
    class Board
    {
        Destroyer destroyer = new Destroyer();
        Submarine submarine = new Submarine();
        Battleship battleship = new Battleship();
        AircraftCarrier aircraftCarrier = new AircraftCarrier();

        public char[,] board = new char[20, 20];
        public Board()
        {

        }
    }
}
