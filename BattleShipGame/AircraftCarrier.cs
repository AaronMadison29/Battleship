 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame
{
    class AircraftCarrier : Ship
    {
        public AircraftCarrier()
        {
            name = "AircraftCarrier";
            boatIndentifier = "[A]";
            addLength = 4;
            health = 5;
        }
    }
}
