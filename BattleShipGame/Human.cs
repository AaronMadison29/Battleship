using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BattleShipGame
{
    class Human : Player
    {

        public Regex coordInput = new Regex(@"\d\d?\,\d\d?");
        public Human()
        {

        }

        public Human(string username)
        {
            name = username;
        }
        public override void SetShips()
        {
            Console.Clear();
            Console.WriteLine("Begin setup for " + name);
            foreach (Ship ship in ships)
            {
                Place(ship);
                GetBoard();
            }
            Console.Clear();
        }
        
        public override void Fire(Player opponent)
        {
            GetOpponentBoard();

            Console.WriteLine($"{name}, what coordinates would you like to fire at?(X/Y)");
            string input = Console.ReadLine();
            string[] array;
            if (coordInput.IsMatch(input))
            {
                array = input.Split(',');
            }
            else
            {
                Console.WriteLine("Please enter a valid coordinate set.");
                Fire(opponent);
                return;
            }

            int x = Convert.ToInt32(array[0]) - 1;
            int y = Convert.ToInt32(array[1]) - 1;

            if (opponent.playerBoard.board[x, y] == "[ ]")
            {
                Console.WriteLine("Sploosh\n");
                opponent.playerBoard.board[x, y] = "[M]";
                opponentBoard.board[x, y] = "[M]";
            }
            else if (opponent.playerBoard.board[x, y] == "[M]")
            {
                Console.WriteLine("You've already missed at that location.");
                Fire(opponent);
                return;
            }
            else if (opponent.playerBoard.board[x, y] == "[H]")
            {
                Console.WriteLine("You've already hit at that location.");
                Fire(opponent);
                return;
            }
            else if (opponent.playerBoard.board[x, y] == "[X]")
            {
                Console.WriteLine("You've already sunk a ship at that location.");
                Fire(opponent);
                return;
            }
            else
            {
                Console.WriteLine("HUHHA!\n");
                opponent.SetDamage(opponent.playerBoard.board[x, y], this, (x, y));
            }
        }

        public void Place(Ship ship)
        {
            Console.WriteLine("Where would you like to start your " + ship.name + "?(X,Y)");
            string input = Console.ReadLine();

            string[] array;
            if (coordInput.IsMatch(input))
            {
                array = input.Split(',');
            }
            else
            {
                Console.WriteLine("Please enter a valid coordinate set.");
                Place(ship);
                return;
            }


            int x1 = Convert.ToInt32(array[0]) - 1;
            int y1 = Convert.ToInt32(array[1]) - 1;

            if (x1 > 9 || y1 > 9)
            {
                Console.WriteLine("That space is invalid, please choose another.");
                Place(ship);
                return;
            }

            if (playerBoard.board[x1, y1] != "[ ]")
            {
                Console.WriteLine("That space is already filled, please choose another.");
                Place(ship);
                return;
            }



            var tupleList = new List<(int, int)>
            {
                (x1+ship.addLength, y1),
                (x1-ship.addLength, y1),
                (x1, y1+ship.addLength),
                (x1, y1-ship.addLength),
            };

            Console.WriteLine("Where would you like to end your " + ship.name + "?(X,Y)");
            bool cleanPlacement = false;
            foreach ((int, int) coords in tupleList)
            {

                if (name == "Destroyer")
                {
                    cleanPlacement = true;
                }
                else if (coords.Item1 > x1)
                {
                    for (int i = x1 + 1; i <= coords.Item1; i++)
                    {
                        if (playerBoard.board[i, coords.Item2] != "[ ]")
                        {
                            cleanPlacement = false;
                            break;
                        }
                        else
                        {
                            cleanPlacement = true;
                        }
                    }
                }
                else if (coords.Item1 < x1)
                {
                    for (int i = x1 - 1; i >= coords.Item1; i--)
                    {
                        if (i < 0)
                        {
                            cleanPlacement = false;
                            break;
                        }
                        if (playerBoard.board[i, coords.Item2] != "[ ]")
                        {
                            cleanPlacement = false;
                            break;
                        }
                        else
                        {
                            cleanPlacement = true;
                        }
                    }
                }
                else if (coords.Item2 > y1)
                {
                    for (int i = y1 + 1; i <= coords.Item2; i++)
                    {
                        if (playerBoard.board[coords.Item1, i] != "[ ]")
                        {
                            cleanPlacement = false;
                            break;
                        }
                        else
                        {
                            cleanPlacement = true;
                        }
                    }
                }
                else if (coords.Item2 < y1)
                {
                    for (int i = y1 - 1; i >= coords.Item2; i--)
                    {
                        if (i < 0)
                        {
                            cleanPlacement = false;
                            break;
                        }
                        if (playerBoard.board[coords.Item1, i] != "[ ]")
                        {
                            cleanPlacement = false;
                            break;
                        }
                        else
                        {
                            cleanPlacement = true;
                        }
                    }
                }

                if (cleanPlacement == true && coords.Item1 + 1 < 11 && coords.Item2 + 1 < 11 && coords.Item1 + 1 > 0 && coords.Item2 + 1 > 0)
                {
                    Console.WriteLine((coords.Item1 + 1) + ", " + (coords.Item2 + 1));
                }

            }

            input = Console.ReadLine();

            if (coordInput.IsMatch(input))
            {
                array = input.Split(',');
            }
            else
            {
                Console.WriteLine("Please enter a valid coordinate set.");
                Place(ship);
                return;
            }

            int x2 = Convert.ToInt32(array[0]) - 1;
            int y2 = Convert.ToInt32(array[1]) - 1;

            bool validInput = false;
            foreach ((int, int) coords in tupleList)
            {
                if (coords.Item1 == x2 && coords.Item2 == y2)
                {
                    validInput = true;
                    break;
                }
            }


            if (validInput == false || playerBoard.board[x2, y2] != "[ ]")
            {
                Console.WriteLine("That is not a valid space, please choose another.");
                Place(ship);
                return;
            }

            ship.coordinates = new List<(int, int)>
            {
                (x1, y1),
                (x2, y2)
            };

            if (x2 > x1)
            {
                for (int i = x1 + 1; i < x2; i++)
                {
                    if (i >= 0 && y2 >= 0)
                    {
                        if (playerBoard.board[i, y2] != "[ ]")
                        {
                            Console.WriteLine("Ship would overlap another previously placed ship, please choose another end location.");
                            Place(ship);
                            return;
                        }
                        ship.coordinates.Add((i, y2));
                        playerBoard.board[i, y2] = ship.boatIndentifier;
                    }

                }
            }
            else if (x2 < x1)
            {
                for (int i = x1 - 1; i > x2; i--)
                {
                    if (i >= 0 && y2 >= 0)
                    {
                        if (playerBoard.board[i, y2] != "[ ]")
                        {
                            Console.WriteLine("Ship would overlap another previously placed ship, please choose another end location.");
                            Place(ship);
                            return;
                        }
                        ship.coordinates.Add((i, y2));
                        playerBoard.board[i, y2] = ship.boatIndentifier;
                    }

                }
            }
            else if (y2 > y1)
            {
                for (int i = y1 + 1; i < y2; i++)
                {
                    if (x2 >= 0 && i >= 0)
                    {
                        if (playerBoard.board[x2, i] != "[ ]")
                        {
                            Console.WriteLine("Ship would overlap another previously placed ship, please choose another end location.");
                            Place(ship);
                            return;
                        }
                        ship.coordinates.Add((x2, i));
                        playerBoard.board[x2, i] = ship.boatIndentifier;
                    }

                }
            }
            else if (y2 < y1)
            {
                for (int i = y1 - 1; i > y2; i--)
                {
                    if (x2 >= 0 && i >= 0)
                    {
                        if (playerBoard.board[x2, i] != "[ ]")
                        {
                            Console.WriteLine("Ship would overlap another previously placed ship, please choose another end location.");
                            Place(ship);
                            return;
                        }
                        ship.coordinates.Add((x2, i));
                        playerBoard.board[x2, i] = ship.boatIndentifier;
                    }
                }
            }


            playerBoard.board[x1, y1] = ship.boatIndentifier;
            playerBoard.board[x2, y2] = ship.boatIndentifier;


        }
    }
}
