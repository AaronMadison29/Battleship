using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame
{
    class Computer : Player
    {
        Random ran;
        public Computer(int compNum, Random ran)
        {
            name = "Computer" + compNum;
            this.ran = ran;
        }

        public override void SetShips()
        {
            foreach(Ship ship in ships)
            {
                Place(ship);
            }
        }
        public void Place(Ship ship)
        {
            int x1 = ran.Next(10);
            int y1 = ran.Next(10);

            if (playerBoard.board[x1, y1] != "[ ]")
            {
                Place(ship);
                return;
            }

            var tupleList = new List<(int, int)>
            {
                (x1+ship.addLength, y1),
                (x1-ship.addLength, y1),
                (x1, y1+ship.addLength),
                (x1, y1-ship.addLength),
            }; for (int i = tupleList.Count - 1; i > 0; i--)
            {
                if (tupleList[i].Item1 > 10 || tupleList[i].Item2 > 10 || tupleList[i].Item1 < 0 || tupleList[i].Item2 < 0)
                {
                    tupleList.RemoveAt(i);
                }
            }


            (int, int) coordinates = tupleList[ran.Next(tupleList.Count)];

            if (coordinates.Item1 > 10 || coordinates.Item2 > 10 || coordinates.Item2 < 0 || coordinates.Item2 < 0 || playerBoard.board[coordinates.Item1, coordinates.Item2] != "[ ]")
            {
                Place(ship);
                return;
            }

            ship.coordinates = new List<(int, int)>
            {
                (x1, y1),
                coordinates
            };

            //if (coordinates.Item1 > x1)
            //{
            //    for (int i = x1; i < coordinates.Item1; i++)
            //    {
            //        if (playerBoard.board[coordinates.Item1, coordinates.Item2] == "[ ]")
            //        {
            //            ship.coordinates.Add((i, coordinates.Item2));
            //            playerBoard.board[i, coordinates.Item2] = ship.boatIndentifier;
            //        }
            //        else
            //        {
            //            Place(ship);
            //            return;
            //        }

            //    }
            //}
            //else if (coordinates.Item1 < x1)
            //{
            //    for (int i = x1; i > coordinates.Item1; i--)
            //    {
            //        if (playerBoard.board[coordinates.Item1, coordinates.Item2] == "[ ]")
            //        {
            //            ship.coordinates.Add((i, coordinates.Item2));
            //            playerBoard.board[i, coordinates.Item2] = ship.boatIndentifier;
            //        }
            //        else
            //        {
            //            Place(ship);
            //            return;
            //        }
            //    }
            //}
            //else if (coordinates.Item2 > y1)
            //{
            //    for (int i = y1; i < coordinates.Item2; i++)
            //    {
            //        if (playerBoard.board[coordinates.Item1, coordinates.Item2] == "[ ]")
            //        {
            //            ship.coordinates.Add((coordinates.Item1, i));
            //            playerBoard.board[coordinates.Item1, i] = ship.boatIndentifier;
            //        }
            //        else
            //        {
            //            Place(ship);
            //            return;
            //        }

            //    }
            //}
            //else if (coordinates.Item2 < y1)
            //{
            //    for (int i = y1; i > coordinates.Item2; i--)
            //    {
            //        if (playerBoard.board[coordinates.Item1, coordinates.Item2] == "[ ]")
            //        {
            //            ship.coordinates.Add((coordinates.Item1, i));
            //            playerBoard.board[coordinates.Item1, i] = ship.boatIndentifier;
            //        }
            //        else
            //        {
            //            Place(ship);
            //            return;
            //        }
            //    }
            //}
            bool cleanPlacement = false;
            do
            {
                if (coordinates.Item1 > x1)
                {
                    for (int i = x1 + 1; i <= coordinates.Item1; i++)
                    {
                        if (playerBoard.board[i, coordinates.Item2] != "[ ]")
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
                else if (coordinates.Item1 < x1)
                {
                    for (int i = x1 - 1; i >= coordinates.Item1; i--)
                    {
                        if (i < 0)
                        {
                            cleanPlacement = false;
                            break;
                        }
                        if (playerBoard.board[i, coordinates.Item2] != "[ ]")
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
                else if (coordinates.Item2 > y1)
                {
                    for (int i = y1 + 1; i <= coordinates.Item2; i++)
                    {
                        if (playerBoard.board[coordinates.Item1, i] != "[ ]")
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
                else if (coordinates.Item2 < y1)
                {
                    for (int i = y1 - 1; i >= coordinates.Item2; i--)
                    {
                        if (i < 0)
                        {
                            cleanPlacement = false;
                            break;
                        }
                        if (playerBoard.board[coordinates.Item1, i] != "[ ]")
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

                if (cleanPlacement == true && coordinates.Item1 + 1 < 11 && coordinates.Item2 + 1 < 11 && coordinates.Item1 + 1 > 0 && coordinates.Item2 + 1 > 0)
                {
                    playerBoard.board[coordinates.Item1, coordinates.Item2] = ship.boatIndentifier;
                }

                



            } while (!cleanPlacement);

            playerBoard.board[x1, y1] = ship.boatIndentifier;
            playerBoard.board[coordinates.Item1, coordinates.Item2] = ship.boatIndentifier;
        }

        public override void Fire(Player opponent)
        {
            int x = ran.Next(10);
            int y = ran.Next(10);

            if (opponent.playerBoard.board[x, y] == "[ ]")
            {
                Console.WriteLine("Sploosh\n");
                opponent.playerBoard.board[x, y] = "[M]";
                opponentBoard.board[x, y] = "[M]";
            }
            else if (opponent.playerBoard.board[x, y] == "[M]")
            {
                Fire(opponent);
                return;
            }
            else if (opponent.playerBoard.board[x, y] == "[H]")
            {
                Fire(opponent);
                return;
            }
            else if (opponent.playerBoard.board[x, y] == "[X]")
            {
                Fire(opponent);
                return;
            }
            else
            {
                Console.WriteLine("HUHHA!\n");
                opponent.SetDamage(opponent.playerBoard.board[x, y], this, (x, y));
            }
        }

    }
}
