using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048_Console
{
    internal enum KeyCode : int
    {
        /// <summary>
        /// The left arrow key.
        /// </summary>
        Left = 0x25,

        /// <summary>
        /// The up arrow key.
        /// </summary>
        Up,

        /// <summary>
        /// The right arrow key.
        /// </summary>
        Right,

        /// <summary>
        /// The down arrow key.
        /// </summary>
        Down
    }
    internal static class NativeKeyboard
    {
        /// <summary>
        /// A positional bit flag indicating the part of a key state denoting
        /// key pressed.
        /// </summary>
        private const int KeyPressed = 0x8000;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetKeyState(int key);
        /// <summary>
        /// Returns a value indicating if a given key is pressed.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns>
        /// <c>true</c> if the key is pressed, otherwise <c>false</c>.
        /// </returns>
        public static bool IsKeyDown(KeyCode key)
        {
            return (GetKeyState((int)key) & KeyPressed) != 0;
        }

        public static bool IsKeyUp(KeyCode key)
        {
            return (GetKeyState((int)key) & KeyPressed) != 0;
        }

        public static bool IsLeft(KeyCode key)
        {
            int g = GetKeyState((int)key);

            return (GetKeyState((int)key) & KeyPressed) != 0;
        }
        /// <summary>
        /// Gets the key state of a key.
        /// </summary>
        /// <param name="key">Virtuak-key code for key.</param>
        /// <returns>The state of the key.</returns>
      //  [System.Runtime.InteropServices.DllImport("user32.dll")]
       // private static extern short GetKeyState(int key);
    }
    class Program
    {
        private static int[][] Tiles;
        private static Random rd;
        private static bool gameOver;
        private static bool isAuthorized;
        private static int score;
        static void Main(string[] args)
        {
            Tiles = new int[4][];

            for (int i = 0; i < 4; i++)
            {
                Tiles[i] = new int[4];
            }

            ConsoleKeyInfo cki;


            // Prevent example from ending if CTL+C is pressed.
            Console.TreatControlCAsInput = true;

           
            Tiles = WriteDefault();
            writeTiles(Tiles);
            
            cki = Console.ReadKey();

            if (cki.Key == ConsoleKey.Enter)
            {
                isAuthorized = true;
                gameOver = false;
                score = 0;
                writeTiles(Tiles);
                Console.WriteLine("Game Begins.\n");
            }
            else
            {
                Console.Write("You dint press the enter button\n");
                cki = Console.ReadKey();
                while (cki.Key != ConsoleKey.Escape)
                {
                    if (cki.Key == ConsoleKey.Enter)
                    {
                        isAuthorized = true;
                        gameOver = false;
                        score = 0;
                        Console.Write("Game Begins\n");
                        cki = Console.ReadKey();
                        break;
                    }
                    Console.Write("You dint press the enter button\n");
                    cki = Console.ReadKey();
                }
            }
            cki = Console.ReadKey();
            do
            {
                if (cki.Key == ConsoleKey.DownArrow)
                {
                    //Arrange the tiles  upward
                    rearrangeTiles(Tiles, KeyCode.Down);
                    //merge the resulting tiles where similar
                    mergeTiles(Tiles, KeyCode.Down);
                    //Rearrange the tiles 
                    rearrangeTiles(Tiles, KeyCode.Down);
                    //Add New Tile
                    addTile();
                    writeTiles(Tiles);
                    Console.Write(cki.Key.ToString());
                    //Renew KeyBoard Listener
                    cki = Console.ReadKey();
                }
                else if (cki.Key == ConsoleKey.UpArrow)
                {
                    //Arrange the tiles  upward
                    rearrangeTiles(Tiles, KeyCode.Up);
                    //merge the resulting tiles where similar
                    mergeTiles(Tiles, KeyCode.Up);
                    //Rearrange the tiles 
                    rearrangeTiles(Tiles, KeyCode.Up);
                    //Add New Tile
                    addTile();
                    //write the resulting solution
                    writeTiles(Tiles);
                    Console.Write(cki.Key.ToString());
                    //Renew KeyBoard Listener
                    cki = Console.ReadKey();
                }
                else if (cki.Key == ConsoleKey.LeftArrow)
                {
                    //Arrange the tiles  Leftward
                    rearrangeTiles(Tiles, KeyCode.Left);
                    //merge the resulting tiles where similar
                    mergeTiles(Tiles, KeyCode.Left);
                    //Rearrange the tiles 
                    rearrangeTiles(Tiles, KeyCode.Left);
                    //Add New Tile
                    addTile();
                    //write the resulting solution
                    writeTiles(Tiles);
                    Console.Write(cki.Key.ToString());
                    //Renew KeyBoard Listener
                    cki = Console.ReadKey();
                }
                else if (cki.Key == ConsoleKey.RightArrow)
                {
                    //Arrange the tiles  Rightward
                    rearrangeTiles(Tiles, KeyCode.Right);
                    //merge the resulting tiles where similar
                    mergeTiles(Tiles, KeyCode.Right);
                    //Rearrange the tiles
                    rearrangeTiles(Tiles, KeyCode.Right);
                    //Add New Tile
                    addTile();
                    //write the resulting solution
                    writeTiles(Tiles);
                    Console.Write(cki.Key.ToString());
                    //Renew KeyBoard Listener
                    cki = Console.ReadKey();
                }
                /*
                Console.Write(" --- You pressed ");
                if ((cki.Modifiers & ConsoleModifiers.Alt) != 0) Console.Write("ALT+");
                if ((cki.Modifiers & ConsoleModifiers.Shift) != 0) Console.Write("SHIFT+");
                if ((cki.Modifiers & ConsoleModifiers.Control) != 0) Console.Write("CTL+");
                Console.WriteLine(cki.Key.ToString());
                 */
            } while (cki.Key != ConsoleKey.Escape && (isAuthorized == true));

        }
      
        public static void writeTiles(int[][] tiles)
        {
            Console.Clear();
            Console.WriteLine("Instructions.");
            Console.WriteLine("=================");
            Console.WriteLine("{0}","Press the Escape (Esc) key to quit:");
            Console.WriteLine("Press the Escape (Esc) key to quit:");
            Console.WriteLine("Press any combination of CTL, ALT, and SHIFT, and a console key.");
            Console.WriteLine("Press the Escape (Esc) key to quit:");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Score : " + score);

            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < Tiles.Count(); i++)
            {
                for (int j = 0; j < Tiles[i].Count(); j++)
                {
                    Console.Write(Indent(2) + Tiles[i][j]);
                }
                Console.WriteLine();
            }
       //     Console.ReadLine();
        }
        public static string Indent(int count)
        {
            return "".PadLeft(count);
        }
        private static int[][] mergeTiles(int[][] tiles, KeyCode key)
        {
            if (key == KeyCode.Left)
            {
                for (int i = 0; i < tiles.Count(); i++)
                {
                    for (int j = 0; j < (tiles.Count() -1); j++)
                    {
                        if ((j + 1) > (Tiles.Count() -1))
                        {
                            tiles[i][j] = tiles[i][j];
                            break;
                        }
                        if (tiles[i][j] == tiles[i][j + 1])
                        {
                            tiles[i][j] =  tiles[i][j] + tiles[i][j + 1];
                            score += tiles[i][j];
                            tiles[i][j + 1] = 0;
                        }

                    }
                }
            }
            else if (key == KeyCode.Right)
            {
                for (int i = 0; i < tiles.Count(); i++)
                {
                    for (int j = (tiles[i].Count() - 1); j > 0 ; j--)
                    {
                        if ((j - 1) < 0)
                        {
                            tiles[i][j] = tiles[i][j];
                            break;
                        }
                        if (tiles[i][j] == tiles[i][j - 1])
                        {
                            tiles[i][j] = tiles[i][j] + tiles[i][j - 1];
                            score += tiles[i][j];
                            tiles[i][j - 1] = 0;
                        }

                    }
                }
            }
            else if (key == KeyCode.Up)
            {
                for (int i = 0; i < tiles.Count(); i++)
                {
                    for (int j = 0; j < Tiles.Count(); j++)
                    {
                        if ((i + 1) > (Tiles.Count() -1))
                        {
                            tiles[i][j] = tiles[i][j];
                            break;
                        }
                        if (tiles[i][j] == tiles[i + 1][j])
                        {
                            tiles[i][j] = tiles[i][j] + tiles[i + 1][j];
                            score += tiles[i][j];
                            tiles[i + 1][j] = 0;
                        }

                    }
                }
            }
            else if (key == KeyCode.Down)
            {
                for (int i = (Tiles.Count() - 1); i >= 0; i--)
                {
                    for (int j = 0; j < Tiles.Count(); j++)
                    {
                        if ((i - 1) < 0)
                        {
                            tiles[i][j] = tiles[i][j];
                            break;
                        }
                        if (tiles[i][j] == tiles[i - 1][j])
                        {
                            tiles[i][j] = tiles[i][j] + tiles[i - 1][j];
                            score += tiles[i][j];
                            tiles[i - 1][j] = 0;
                        }

                    }
                }
            }
            return Tiles;
        }
        private static int[][] rearrangeTiles(int[][] tiles, KeyCode key)
        {
            int[][] temp;
            int count = 0;
            if (key == KeyCode.Left)
            {
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
        private static int[][] addTile()
        {
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
                    py = c;
                    availableInd = randPosition(py);
                    if (availableInd.Count > 0)
                        break;
                }
                if (availableInd.Count == 0)
                {
                    gameOver = true;
                    Console.WriteLine("Game Over");
                   
                }
            }
            int r = rd.Next(0, availableInd.Count);
            int newPx = availableInd[r];
            if (Tiles[py][newPx] == 0)
            {
                Tiles[py][newPx] = rd.Next(0, 20) == 0 ? rd.Next(0, 15) == 0 ? 8 : 4 : 2;
            }
            else
            {
                py = py; // sHOULDN'T REACH HERE 
            }

            return Tiles;
        }
        
        public static List<int> randPosition(int num)
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
        private static int[][] WriteDefault()
        {
            rd = new Random();
            int pxPrev, pyPrev;
            for (int i = 0; i < 2; i++)
            {
                int px = rd.Next(0, 4);
                int py = rd.Next(0, 4);
                pxPrev = px;
                pyPrev = py;
                if (Tiles[px][py] == 0)
                {
                    Tiles[px][py] = rd.Next(0, 20) == 0 ? rd.Next(0, 15) == 0 ? 8 : 4 : 2;

                    int Ha = rd.Next(0, 20) == 0 ? rd.Next(0, 15) == 0 ? 8 : 4 : 2;

                }
            }

            return Tiles;
        }
    }
}
