using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BattleShipGame
{
    class Program
    {
        static void Main(string[] args)
        {


            Game game = new Game();

            Interface.TitleScreen();

            game.TitleScreen();

            if (!game.saveLoaded)
            {
                int players = game.PlayerChoice();
                game.SetPlayers(players);
                game.BoardSetup(players);
            }

            game.Run();

            Console.ReadLine();
        }   
    }
}
