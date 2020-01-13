using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame
{
    class Ship
    {
        public string name;
        public char boatChar;
        public List<(int, int)> coordinates;
        public int addLength;

        public Ship()
        {

        }


        public void Place(Board boardIn)
        {
            Console.WriteLine("Where would you like to start your " + name + "?(X,Y)");
            string[] input = Console.ReadLine().Split(',');

            int x1 = Convert.ToInt32(input[0]);
            int y1 = Convert.ToInt32(input[1]);

            boardIn.board[x1, y1] = boatChar;

            var tupleList = new List<(int, int)>
            {
                (x1+addLength, y1),
                (x1-addLength, y1),
                (x1, y1+addLength),
                (x1, y1-addLength)
            };
            foreach ((int, int) coords in tupleList)
            {
                Console.WriteLine(coords);
            }

            Console.WriteLine("Where would you like to end your " + name + "?(X,Y)");
            input = Console.ReadLine().Split(',');
            int x2 = Convert.ToInt32(input[0]);
            int y2 = Convert.ToInt32(input[1]);

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
                    }
                    
                }
            }
            else if(x2 < x1)
            {
                for (int i = x1 + 1; i > x2; i--)
                {
                    if(i > 0 && y2 > 0)
                    {
                        coordinates.Add((i, y2));
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
                    }
                }
            }


            boardIn.board[x2, y2] = boatChar;

            

            


        }
    }
}
