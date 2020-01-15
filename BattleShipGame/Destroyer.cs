using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame
{
    class Destroyer : Ship
    {
        public Destroyer()
        {
            name = "Destroyer";
            boatIndentifier = "[D]";
            addLength = 1;
            health = 2;
        }
    }
}
