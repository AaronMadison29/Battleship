using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BattleShipGame
{

    class FileReader
    {

        public StreamReader sr;
        string path;

        public FileReader(string path)
        {
            this.path = path;
        }
        public Dictionary<string, string> LoadUserFile(Dictionary<string, string> users)
        {
            sr = new StreamReader(path);
            string line;
            string[] list;
            while ((line = sr.ReadLine()) != null)
            {
                list = line.Split(' ');
                users.Add(list[0], list[1]);
            }
            sr.Close();
            return users;
        }

        public void LoadSaveFile(Player player1, Player player2)
        {
            path += player1.name + ".txt";
            sr = new StreamReader(path);

            string[,] board = new string[10,10];

            string file = sr.ReadToEnd();

            string board1 = file.Substring(file.IndexOf('{') + 1, file.IndexOf('}') - 1 - file.IndexOf('{'));
            file = file.Remove(file.IndexOf('{'), 1);
            file = file.Remove(file.IndexOf('}'), 1);
            string[] array = board1.Split(',');

            int X = 0;
            int Y = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {




                if (i != 0 && i % 10 == 0)
                {
                    Y++;
                    X = 0;
                }

                player1.playerBoard.board[X, Y] = array[i];
                X++;
            }

            board1 = file.Substring(file.IndexOf('{') + 1, file.IndexOf('}') - 1 - file.IndexOf('{'));
            file = file.Remove(file.IndexOf('{'), 1);
            file = file.Remove(file.IndexOf('}'), 1);

            array = board1.Split(',');

            X = 0;
            Y = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {




                if (i != 0 && i % 10 == 0)
                {
                    Y++;
                    X = 0;
                }

                player1.opponentBoard.board[X, Y] = array[i];
                X++;
            }


            board1 = file.Substring(file.IndexOf('{') + 1, file.IndexOf('}') - 1 - file.IndexOf('{'));
            file = file.Remove(file.IndexOf('{'), 1);
            file = file.Remove(file.IndexOf('}'), 1);

            array = board1.Split(',');

            X = 0;
            Y = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {




                if (i != 0 && i % 10 == 0)
                {
                    Y++;
                    X = 0;
                }

                player2.playerBoard.board[X, Y] = array[i];
                X++;
            }


            board1 = file.Substring(file.IndexOf('{') + 1, file.IndexOf('}') - 1 - file.IndexOf('{'));
            file = file.Remove(file.IndexOf('{'), 1);
            file = file.Remove(file.IndexOf('}'), 1);

            array = board1.Split(',');

            X = 0;
            Y = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {




                if (i != 0 && i % 10 == 0)
                {
                    Y++;
                    X = 0;
                }

                board[X, Y] = array[i];
                X++;
            }
        }
    

        public bool UserVerification(string username, Dictionary<string, string> users)
        {
            bool correctPassword = false;
            if (users.ContainsKey(username))
            {
                while(!correctPassword)
                {
                    string password = Interface.EnterPassword();
                    correctPassword = PasswordVerification(username, password, users);
                }
            }
            else
            {
                Console.WriteLine("Invalid username");
                return false;
            }
            return true;
        }

        public bool PasswordVerification(string username, string password, Dictionary<string, string> users)
        {
            foreach (KeyValuePair<string, string> entry in users)
            {
                if (entry.Key.Equals(username) && entry.Value.Equals(password))
                {
                    Console.WriteLine($"Logging in as {username}");
                    return true;
                }
            }
            Console.WriteLine("Invalid password");
            Console.Write("Try again: ");
            return false;
        }

        public void FileOutput(Dictionary<string, string> users)
        {
            users.Clear();
            users = LoadUserFile(users);
            foreach(var entry in users)
            {
                Console.WriteLine($"{entry.Key} {entry.Value}");
            }
        }

        public bool CheckUsername(string username, Dictionary<string, string> users)
        {
            if (users.ContainsKey(username))
            {
                Console.WriteLine("Sorry that username is already taken.");
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
