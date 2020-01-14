﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame
{
    class Ship
    {
        public string name;
        public string boatChar;
        public List<(int, int)> coordinates;
        public int addLength;

        public Ship()
        {

        }


        public void Place(Board boardIn)
        {
            Console.WriteLine("Where would you like to start your " + name + "?(X,Y)");
            string[] input = Console.ReadLine().Split(',');

            int x1 = Convert.ToInt32(input[0]) - 1;
            int y1 = Convert.ToInt32(input[1]) - 1;

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

            foreach ((int, int) coords in tupleList)
            {
                
                if((coords.Item1 + 1) >= 1 && (coords.Item2 + 1) >= 1 && (coords.Item1 + 1) <= 10 && (coords.Item2 + 1) <= 10 && boardIn.board[coords.Item1, coords.Item2] == "[ ]")
                {
                    Console.WriteLine((coords.Item1 + 1) + ", " + (coords.Item2 + 1));
                }
            }

            input = Console.ReadLine().Split(',');
            int x2 = Convert.ToInt32(input[0]) - 1;
            int y2 = Convert.ToInt32(input[1]) - 1;
            bool validInput = false;
            foreach((int, int) coords in tupleList)
            {
                if(coords.Item1 == x2 && coords.Item2 == y2)
                {
                    validInput = true;
                    break;
                }
            }


            if (validInput == false || boardIn.board[x1, y1] != "[ ]")
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
                    if(i > 0 && y2 > 0)
                    {
                        coordinates.Add((i, y2));
                        boardIn.board[i, y2] = boatChar;
                    }
                    
                }
            }
            else if(x2 < x1)
            {
                for (int i = x1; i > x2; i--)
                {
                    if(i > 0 && y2 > 0)
                    {
                        coordinates.Add((i, y2));
                        boardIn.board[i, y2] = boatChar;
                    }
                    
                }
            }
            else if(y2 > y1)
            {
                for (int i = y1 + 1; i < y2; i++)
                {
                    if (x2 > 0 && i > 0)
                    {
                        coordinates.Add((x2, i));
                        boardIn.board[x2, i] = boatChar;
                    }

                }
            }
            else if (y2 < y1)
            {   
                for (int i = y1 + 1; i > y2; i--)
                {
                    if (x2 > 0 && i > 0)
                    {
                        coordinates.Add((x2, i));
                        boardIn.board[x2, i] = boatChar;
                    }
                }
            }


            boardIn.board[x1, y1] = boatChar;
            boardIn.board[x2, y2] = boatChar;


        }
    }
}
