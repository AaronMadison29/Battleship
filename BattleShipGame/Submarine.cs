using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame
{
    class Submarine : Ship
    {
        public Submarine()
        {
            name = "Submarine";
            boatIndentifier = "[S]";
            addLength = 2;
            health = 3;
        }
    }
}
