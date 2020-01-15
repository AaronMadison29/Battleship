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

            Player player1 = new Player();
            Player player2 = new Player();

            player1.SetName();
            player2.SetName();

            Game game = new Game(player1, player2);

            game.BoardSetup();
            game.Run();

            Console.ReadLine();
        }
    }
}
