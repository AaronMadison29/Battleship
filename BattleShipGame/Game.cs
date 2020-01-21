using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BattleShipGame
{
    class Game
    {
        string userLog = "BattleShipGame\\SaveGames\\UserLog.txt";
        string saveGame = "BattleShipGame\\SaveGames\\";
        Player player1;
        Player player2;
        Regex playerIntput = new Regex("[0-2]");
        Random ran = new Random();
        public Dictionary<string, string> users;
        public FileReader userFileReader;
        public FileWriter userFileWriter;
        public FileReader saveFileReader;
        public FileWriter saveFileWriter;
        public bool saveLoaded = false;

        public Game()
        {
            users = new Dictionary<string, string>();
            userFileReader = new FileReader(userLog);
            userFileWriter = new FileWriter(userLog);
            saveFileReader = new FileReader(saveGame);
            saveFileWriter = new FileWriter(saveGame);

            userFileReader.LoadUserFile(users);
        }

        public int PlayerChoice()
        {
            
            Console.WriteLine("How many players are there? 0, 1, or 2:");

            string input = Console.ReadLine();
            int players;

            if(playerIntput.IsMatch(input))
            {
                players = Convert.ToInt32(input);
            }
            else
            {
                Console.WriteLine("Please enter a valid input.");
                PlayerChoice();
                return 0;
            }

            return players;
        }

        public void SetPlayers(int players)
        {
            switch(players)
            {
                case 0:
                    player1 = new Computer(1, ran);
                    player2 = new Computer(2, ran);
                    break;
                case 1:
                    if (player1 is null)
                    {
                        player1 = new Human();
                        player1.SetName();
                    }
                    player2 = new Computer(1, ran);
                    break;
                case 2:
                    if (player1 is null)
                    {
                        player1 = new Human();
                        player1.SetName();
                    }
                    player2 = new Human();
                    player2.SetName();
                    break;
            }
            
        }

        public void BoardSetup(int players)
        {
            
            player1.SetShips();
            player2.SetShips();
            if (players == 0)
            {
                player1.GetBoard();
                player2.GetBoard();
            }
            Console.WriteLine("Board setup complete");
            Console.WriteLine("Press enter to start the game.");
            Console.ReadLine();
            Console.Clear();


        }

        public void TitleScreen()
        {
            string input = Interface.UserTitleScreen();

            switch (input)
            {
                case "1":
                    NewUser();
                    break;
                case "2":
                    PreviousUser();
                    break;
                default:
                    TitleScreen();
                    break;
            }
            userFileWriter.SaveUserFile(users);

            if(Interface.SaveOption() == "y")
            {
                SaveRestore();
                saveLoaded = true;
            }
        }

        public void NewUser()
        {
            string username = Interface.NewUsernameInput();

            if(userFileReader.CheckUsername(username, users))
            {
                string password = Interface.SetPassword(username);
                userFileWriter.WriteNewUser(username, password, users);
            }
            else
            {
                NewUser();
            }
            player1 = new Human(username);
            player2 = new Computer(1, ran);
        }

        public void PreviousUser()
        {
            string username = Interface.EnterUsername();

            if(userFileReader.UserVerification(username, users))
            {
                player1 = new Human(username);
                player2 = new Computer(1, ran);
            }
            else
            {
                PreviousUser();
            }
        }

        public bool GameOver()
        {
            if (player1.ships.Count == 0)
            {
                Console.Clear();
                Console.WriteLine($"{player2.name} wins!");
                return true;

            }
            else if (player2.ships.Count == 0)
            {
                Console.Clear();
                Console.WriteLine($"{player1.name} wins!");
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Run()
        {
            do
            {
                player1.GetBoard();
                player1.Fire(player2);

                if (GameOver())
                {
                    break;
                }
                Interface.EndOfTurn();

                player2.GetBoard();
                player2.Fire(player1);

                if (GameOver())
                {
                    break;
                }

                SaveGame(Interface.SaveGame());
                Interface.EndOfTurn();


            } while (true);
        }

        public void SaveGame(string prompt)
        {
            if(prompt == "y")
            {
                saveFileWriter.SaveGame(player1, player2);
                return;
            }
            else
            {
                return;
            }
        }

        public void SaveRestore()
        {
            saveFileReader.LoadSaveFile(player1, player2);
        }
    }
}
