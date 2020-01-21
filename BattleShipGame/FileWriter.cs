using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame
{

    
    class FileWriter
    {
        public FileStream fs;
        public StreamWriter sw;
        public string path;
        public FileWriter(string path)
        {
            this.path = path;
        }

        public Dictionary<string, string> WriteNewUser(string username, string password, Dictionary<string, string> users)
        {
            users.Add(username, password);
            return users;
        }

        public void SaveUserFile(Dictionary<string, string> users)
        {
            sw = new StreamWriter(path);
            foreach (var entry in users)
            {
                sw.WriteLine($"{entry.Key} {entry.Value}");
            }
            sw.Close();
        }

        public void SaveGame(Player player1, Player player2)
        {
            path += player1.name + ".txt";
            fs = File.Create(path);
            fs.Close();
            sw = new StreamWriter(path);

            sw.WriteLine(player1.name);
            sw.WriteLine("playerboard");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    sw.Write(player1.playerBoard.board[j, i] + ",");
                }
            }
            sw.WriteLine("\nopponentboard");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    sw.Write(player1.opponentBoard.board[j, i] + ",");
                }
            }
            sw.WriteLine("\n" + player2.name);
            sw.WriteLine("playerboard");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    sw.Write(player2.playerBoard.board[j, i]+ ",");
                }
            }
            sw.WriteLine("\nopponentboard");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    sw.Write(player2.opponentBoard.board[j, i] + ",");
                }
            }
            sw.Close();
        }
    }
}
