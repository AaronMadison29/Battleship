using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame
{
    class Board
    {

        public string[,] board;
        public Board()
        {
            board = new string[10, 10];
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    board[i, j] = "[ ]";
                }
            }
        }
    }
}
