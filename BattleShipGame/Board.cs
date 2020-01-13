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

        public string[,] board;
        public Board()
        {
            board = new string[20, 20];
            for(int i = 0; i < 20; i++)
            {
                for(int j = 0; j < 20; j++)
                {
                    board[i, j] = "[ ]";
                }
            }
        }
    }
}
