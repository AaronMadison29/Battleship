using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame
{
    static class Interface
    {
        public static void TitleScreen()
        {
            Console.WriteLine("BATTLESHIP");
            Console.WriteLine("Would you like to start a new game or load a save?");
        }

        public static (string, string) Login()
        {
            string username = EnterUsername();
            string password = EnterPassword();
            return (username, password);
        }
        public static string EnterUsername()
        {
            Console.Write("Please enter your username:");
            return Console.ReadLine();
        }
        public static string EnterPassword()
        {
            Console.Write("Please enter your password:");
            return Console.ReadLine();
        }

        public static string UserTitleScreen()
        {

            Console.WriteLine("1: New User");
            Console.WriteLine("2: Previous User");

            return Console.ReadLine();
        }

        public static string NewUsernameInput()
        {
            Console.Write("Choose a username: ");
            string username = Console.ReadLine();
            return username;
        }
        public static string SetPassword(string username)
        {
            Console.Write("Enter your new password: ");
            string password = Console.ReadLine();
            return password;
        }

        public static void EndOfTurn()
        {
            Console.Write("Press enter to pass the turn.");
            Console.ReadLine();
            Console.Clear();
        }

        public static string SaveGame()
        {
            Console.WriteLine("Would you like to save the game?(y/n)");
            return Console.ReadLine();
        }

        public static string SaveOption()
        {
            Console.WriteLine("Would you like to load a previous save game?(y/n)");
            string choice = Console.ReadLine();
            Console.Clear();
            return choice;
        }
    }
}
