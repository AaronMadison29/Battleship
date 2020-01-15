using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BattleShipGame
{
    class Ship
    {
        public string name;
        public string boatIndentifier;
        public List<(int, int)> coordinates;
        Regex coordInput = new Regex(@"\d\d?\,\d\d?");
        public int addLength;
        public int health;

        public Ship()
        {

        }

        public void Sink(Player player, Player opponent)
        {
            Console.WriteLine($"You sunk {player.name}'s {this.name}\n");
            foreach((int, int) coord in coordinates)
            {
                player.playerBoard.board[coord.Item1, coord.Item2] = "[X]";
                opponent.opponentBoard.board[coord.Item1, coord.Item2] = "[X]";
            }
            
        }
    }
}
