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


        public void Place(Board boardIn)
        {
            Console.WriteLine("Where would you like to start your " + name + "?(X,Y)");
            string input = Console.ReadLine();

            string[] array;
            if (coordInput.IsMatch(input))
            {
                array = input.Split(',');
            }
            else
            {
                Console.WriteLine("Please enter a valid coordinate set.");
                Place(boardIn);
                return;
            }


            int x1 = Convert.ToInt32(array[0]) - 1;
            int y1 = Convert.ToInt32(array[1]) - 1;

            if (x1 > 9 || y1 > 9)
            {
                Console.WriteLine("That space is invalid, please choose another.");
                Place(boardIn);
                return;
            }

            if (boardIn.board[x1, y1] != "[ ]")
            {
                Console.WriteLine("That space is already filled, please choose another.");
                Place(boardIn);
                return;
            }



            var tupleList = new List<(int, int)>
            {
                (x1+addLength, y1),
                (x1-addLength, y1),
                (x1, y1+addLength),
                (x1, y1-addLength),
            };

            Console.WriteLine("Where would you like to end your " + name + "?(X,Y)");
            bool cleanPlacement = false;
            foreach ((int, int) coords in tupleList)
            {

                if(name == "Destroyer")
                {
                    cleanPlacement = true;
                }
                else if (coords.Item1 > x1)
                {
                    for (int i = x1 + 1; i <= coords.Item1; i++)
                    {
                        if(boardIn.board[i, coords.Item2] != "[ ]")
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
                        if(i < 0)
                        {
                            cleanPlacement = false;
                            break;
                        }
                        if (boardIn.board[i, coords.Item2] != "[ ]")
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
                        if (boardIn.board[coords.Item1, i] != "[ ]")
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
                        if (boardIn.board[coords.Item1, i] != "[ ]")
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

                if(cleanPlacement == true && coords.Item1 + 1 < 11 && coords.Item2 + 1 < 11 && coords.Item1 + 1 > 0 && coords.Item2 + 1 > 0)
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
                Place(boardIn);
                return;
            }

            int x2 = Convert.ToInt32(array[0]) - 1;
            int y2 = Convert.ToInt32(array[1]) - 1;

            bool validInput = false;
            foreach((int, int) coords in tupleList)
            {
                if(coords.Item1 == x2 && coords.Item2 == y2)
                {
                    validInput = true;
                    break;
                }
            }


            if (validInput == false || boardIn.board[x2, y2] != "[ ]")
            {
                Console.WriteLine("That is not a valid space, please choose another.");
                Place(boardIn);
                return;
            }

            coordinates = new List<(int, int)>
            {
                (x1, y1),
                (x2, y2)
            };

            if(x2 > x1)
            {
                for (int i = x1 + 1; i < x2; i++)
                {
                    if(i >= 0 && y2 >= 0)
                    {
                        if (boardIn.board[i, y2] != "[ ]")
                        {
                            Console.WriteLine("Ship would overlap another previously placed ship, please choose another end location.");
                            Place(boardIn);
                            return;
                        }
                        coordinates.Add((i, y2));
                        boardIn.board[i, y2] = boatIndentifier;
                    }
                    
                }
            }
            else if(x2 < x1)
            {
                for (int i = x1 - 1; i > x2; i--)
                {
                    if(i >= 0 && y2 >= 0)
                    {
                        if (boardIn.board[i, y2] != "[ ]")
                        {
                            Console.WriteLine("Ship would overlap another previously placed ship, please choose another end location.");
                            Place(boardIn);
                            return;
                        }
                        coordinates.Add((i, y2));
                        boardIn.board[i, y2] = boatIndentifier;
                    }
                    
                }
            }
            else if(y2 > y1)
            {
                for (int i = y1 + 1; i < y2; i++)
                {
                    if (x2 >= 0 && i >= 0)
                    {
                        if (boardIn.board[x2, i] != "[ ]")
                        {
                            Console.WriteLine("Ship would overlap another previously placed ship, please choose another end location.");
                            Place(boardIn);
                            return;
                        }
                        coordinates.Add((x2, i));
                        boardIn.board[x2, i] = boatIndentifier;
                    }

                }
            }
            else if (y2 < y1)
            {   
                for (int i = y1 - 1; i > y2; i--)
                {
                    if (x2 >= 0 && i >= 0)
                    {
                        if (boardIn.board[x2, i] != "[ ]")
                        {
                            Console.WriteLine("Ship would overlap another previously placed ship, please choose another end location.");
                            Place(boardIn);
                            return;
                        }
                        coordinates.Add((x2, i));
                        boardIn.board[x2, i] = boatIndentifier;
                    }
                }
            }


            boardIn.board[x1, y1] = boatIndentifier;
            boardIn.board[x2, y2] = boatIndentifier;


        }
    }
}
