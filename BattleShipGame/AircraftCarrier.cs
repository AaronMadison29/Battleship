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
            boatChar = 'A';
            addLength = 4;
        }
    }
}
