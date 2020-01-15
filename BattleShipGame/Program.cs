using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            int players = game.PlayerChoice();
            while(true)
            {
                game.SetPlayers(players);

                game.BoardSetup(players);
            }
            

            game.Run();

            Console.ReadLine();
        }
    }
}
