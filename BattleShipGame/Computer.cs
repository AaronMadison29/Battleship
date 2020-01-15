using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame
{
    class Computer : Player
    {
        public Computer(int compNum)
        {
            name = "Computer" + compNum;
        }

        public override void SetShips()
        {
            throw new NotImplementedException();
        }

        public override void Fire(Player opponent)
        {
            throw new NotImplementedException();
        }

    }
}
