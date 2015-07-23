using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048_Console
{
    public class TilesCl
    {
        private int[][] Tiles;
        private Random rd;
        public TilesCl(int[][] tiles)
        {
            Tiles = tiles;
        }
        public int[][] mergeTiles(KeyCode key)
        {
            //Merge similar tiles
            if (key == KeyCode.Left)
            {
                //Check for left arrow
                for (int i = 0; i < Tiles.Count(); i++)
                {
                    for (int j = 0; j < (Tiles.Count() - 1); j++)
                    {
                        if ((j + 1) > (Tiles.Count() - 1))
                        {
                            Tiles[i][j] = Tiles[i][j];
                            break;
                        }
                        if (Tiles[i][j] == Tiles[i][j + 1])
                        {
                            Tiles[i][j] = Tiles[i][j] + Tiles[i][j + 1];
                            GameModel.Score += Tiles[i][j];
                            Tiles[i][j + 1] = 0;
                        }

                    }
                }
            }
            else if (key == KeyCode.Right)
            {
                //merge for right arrow
                for (int i = 0; i < Tiles.Count(); i++)
                {
                    for (int j = (Tiles[i].Count() - 1); j > 0; j--)
                    {
                        if ((j - 1) < 0)
                        {
                            Tiles[i][j] = Tiles[i][j];
                            break;
                        }
                        if (Tiles[i][j] == Tiles[i][j - 1])
                        {
                            Tiles[i][j] = Tiles[i][j] + Tiles[i][j - 1];
                            GameModel.Score += Tiles[i][j];
                            Tiles[i][j - 1] = 0;
                        }

                    }
                }
            }
            else if (key == KeyCode.Up)
            {
                //merging upward
                for (int i = 0; i < Tiles.Count(); i++)
                {
                    for (int j = 0; j < Tiles.Count(); j++)
                    {
                        if ((i + 1) > (Tiles.Count() - 1))
                        {
                            Tiles[i][j] = Tiles[i][j];
                            break;
                        }
                        if (Tiles[i][j] == Tiles[i + 1][j])
                        {
                            Tiles[i][j] = Tiles[i][j] + Tiles[i + 1][j];
                            GameModel.Score += Tiles[i][j];
                            Tiles[i + 1][j] = 0;
                        }

                    }
                }
            }
            else if (key == KeyCode.Down)
            {
                //merge downward
                for (int i = (Tiles.Count() - 1); i >= 0; i--)
                {
                    for (int j = 0; j < Tiles.Count(); j++)
                    {
                        if ((i - 1) < 0)
                        {
                            Tiles[i][j] = Tiles[i][j];
                            break;
                        }
                        if (Tiles[i][j] == Tiles[i - 1][j])
                        {
                            Tiles[i][j] = Tiles[i][j] + Tiles[i - 1][j];
                            GameModel.Score += Tiles[i][j];
                            Tiles[i - 1][j] = 0;
                        }

                    }
                }
            }
            return Tiles;
        }

        public int[][] rearrangeTiles(KeyCode key)
        {
            //Arrange the tiles and brig them together 
            if (key == KeyCode.Left)
            {
                //arrange to the left
                for (int i = 0; i < Tiles.Count(); i++)
                {
                    for (int j = 0; j < Tiles.Count(); j++)
                    {
                        if (Tiles[i][j] > 0)
                            continue;
                        int u = j;

                        while (u < Tiles.Count())
                        {
                            if (Tiles[i][j] > 0)
                                break;
                            if (Tiles[i][u] > 0)
                            {
                                Tiles[i][j] = Tiles[i][u];
                                Tiles[i][u] = 0;
                            }
                            u++;
                        }
                    }
                }

            }
            else if (key == KeyCode.Right)
            {
                //arrange to the right
                for (int i = 0; i < Tiles.Count(); i++)
                {
                    for (int j = (Tiles.Count() - 1); j >= 0; j--)
                    {
                        if (Tiles[i][j] > 0)
                            continue;
                        int u = j;
                        while (u < Tiles.Count() && u >= 0)
                        {
                            if (Tiles[i][j] > 0)
                                break;
                            if (Tiles[i][u] > 0)
                            {
                                Tiles[i][j] = Tiles[i][u];
                                Tiles[i][u] = 0;
                            }
                            u--;
                        }

                    }
                }

            }
            else if (key == KeyCode.Up)
            {
                //arrange updarward
                for (int i = 0; i < Tiles.Count(); i++)
                {
                    for (int j = 0; j < Tiles.Count(); j++)
                    {
                        if (Tiles[i][j] > 0)
                            continue;

                        int u = i;


                        while (u < Tiles.Count())
                        {
                            if (Tiles[i][j] > 0)
                                break;
                            if (Tiles[u][j] > 0)
                            {
                                Tiles[i][j] = Tiles[u][j];
                                Tiles[u][j] = 0;
                            }
                            u++;
                        }



                    }
                }

            }
            else if (key == KeyCode.Down)
            {
                //arrange downward
                for (int i = (Tiles.Count() - 1); i >= 0; i--)
                {
                    for (int j = 0; j < Tiles.Count(); j++)
                    {
                        if (Tiles[i][j] > 0)
                            continue;

                        int u = i;


                        while (u < Tiles.Count() && u >= 0)
                        {
                            if (Tiles[i][j] > 0)
                                break;
                            if (Tiles[u][j] > 0)
                            {

                                Tiles[i][j] = Tiles[u][j];
                                Tiles[u][j] = 0;
                            }
                            u--;
                        }



                    }
                }

            }

            return Tiles;
        }
        public int[][] addTile()
        {
            //Add a new random tile
            rd = new Random();
            int px, py;
            px = rd.Next(0, 4);
            py = rd.Next(0, 4);

            List<int> availableInd = randPosition(py);

            //Incase The above fails. I would seach row by row
            //for an empty tile below
            if (availableInd.Count == 0)
            {
                for (int c = 0; c < Tiles.Count(); c++)
                {
                    py = c; //reset py
                    availableInd = randPosition(py);//try with each row
                    if (availableInd.Count > 0)
                        break;
                }
                if (availableInd.Count == 0)
                {
                    GameModel.isGameOver = true;
                    Console.WriteLine("Game Over");
                    Console.WriteLine("Retry ? Y / N ");
                    string restart = Console.ReadLine();
                    while (true)
                    {
                        if (restart.ToUpper() == "Y")
                        {
                            //restart
                            Program.play();
                            return Tiles;
                        }
                        else if (restart.ToUpper() == "N")
                        {
                            //exit game
                            Environment.Exit(0);
                        }
                    }
                }
            }
            int r = rd.Next(0, availableInd.Count);
            int newPx = availableInd[r];
            if (Tiles[py][newPx] == 0)
            {
                //our random tile is being put to it position here
                Tiles[py][newPx] = rd.Next(0, 20) == 0 ? rd.Next(0, 15) == 0 ? 8 : 4 : 2;
            }
            else
            {
                py = py; // sHOULDN'T REACH HERE 
            }

            return Tiles;
        }
        private List<int> randPosition(int num)
        {
            //GET THE INDEXES OF THE EMPTY TILES
            List<int> indexes = new List<int>();

            //  var emptyTiles = arr.Where(x => x == 0).ToList();
            indexes = Tiles[num].Select((s, index) => new { s, index })
                      .Where(x => x.s == 0)
                      .Select(x => x.index)
                      .ToList();


            return indexes;
        }

    }
}
