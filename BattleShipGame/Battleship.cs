using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame
{
    class Battleship : Ship
    {
        public Battleship()
        {
            name = "Battleship";
            boatIndentifier = "[B]";
            addLength = 3;
            health = 4;
        }
    }
}
