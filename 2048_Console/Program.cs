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
        private static int[][] iBoard;
        private static Random rd;
        static void Main(string[] args)
        {
            iBoard = new int[4][];

            for (int i = 0; i < 4; i++)
            {
                iBoard[i] = new int[4];
            }

            ConsoleKeyInfo cki;

            
            // Prevent example from ending if CTL+C is pressed.
            Console.TreatControlCAsInput = true;

            Console.WriteLine("Press any combination of CTL, ALT, and SHIFT, and a console key.");
            Console.WriteLine("Press the Escape (Esc) key to quit: \n");
            iBoard = WriteDefault();
           // writeTiles(iBoard);
            do
            {
                cki = Console.ReadKey();

                if (cki.Key == ConsoleKey.DownArrow)
                {
                    rearrangeTiles(iBoard, KeyCode.Down);
                    writeTiles(iBoard);
                    Console.Write(cki.Key.ToString());
                }
                else if (cki.Key == ConsoleKey.UpArrow)
                {
                    rearrangeTiles(iBoard, KeyCode.Up);
                    writeTiles(iBoard);
                    Console.Write(cki.Key.ToString());
                }
                else if (cki.Key == ConsoleKey.LeftArrow)
                {
                    rearrangeTiles(iBoard, KeyCode.Left);
                    writeTiles(iBoard);
                    Console.Write(cki.Key.ToString());
                }
                else if (cki.Key == ConsoleKey.RightArrow)
                {
                    rearrangeTiles(iBoard, KeyCode.Right);
                    writeTiles(iBoard);
                    Console.Write(cki.Key.ToString());
                }
                /*
                Console.Write(" --- You pressed ");
                if ((cki.Modifiers & ConsoleModifiers.Alt) != 0) Console.Write("ALT+");
                if ((cki.Modifiers & ConsoleModifiers.Shift) != 0) Console.Write("SHIFT+");
                if ((cki.Modifiers & ConsoleModifiers.Control) != 0) Console.Write("CTL+");
                Console.WriteLine(cki.Key.ToString());
                 */
            } while (cki.Key != ConsoleKey.Escape);

            /*
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    iBoard[i][j] = (i * j);
                    Console.Write(iBoard[i][j]);
                }
                Console.WriteLine();
            }
             */
          

           
           

        }
  
        public static void writeTiles(int[][] tiles)
        {
            Console.Clear();

            for (int i = 0; i < iBoard.Count(); i++)
            {
                for (int j = 0; j < iBoard[i].Count(); j++)
                {
                    Console.Write(Indent(2) + iBoard[i][j]);
                }
                Console.WriteLine();
            }
         //   Console.ReadLine();
        }
        public static string Indent(int count)
        {
            return "".PadLeft(count);
        }
        public static int[][] mergeTiles(int[][] tiles, KeyCode key)
        {

            return iBoard;
        }
        private static int[][] rearrangeTiles(int[][] tiles, KeyCode key)
        {
            int[][] temp ;
            int count = 0;
            if (key == KeyCode.Left)
            {
                temp = new int[iBoard.Count()][];

                foreach(int[] arr in iBoard)
                {
                    Array.Sort<int>(arr,
                    new Comparison<int>(
                            (i1, i2) => i2.CompareTo(i1)
                    ));

                    temp[count] = arr;
                    count++;
                }

                iBoard = temp;
                
            }
            else if (key == KeyCode.Right)
            {
                temp = new int[iBoard.Count()][];

                foreach (int[] arr in iBoard)
                {
                    Array.Sort<int>(arr,
                    new Comparison<int>(
                            (i1, i2) => i1.CompareTo(i2)
                    ));

                    temp[count] = arr;
                    count++;
                }

                iBoard = temp;
               
            }
            else if (key == KeyCode.Up)
            {
                for (int i = 0; i < iBoard.Count(); i++)
                {
                    for (int j = 0; j < iBoard.Count(); j++)
                    {
                        if (iBoard[i][j] > 0)
                            continue;
                        if (iBoard[i][j] == 0)
                        {
                            int u = i;


                            while (u < iBoard.Count())
                            {
                                if (iBoard[i][j] > 0)
                                    break;
                                if (iBoard[u][j] > 0)
                                {

                                    iBoard[i][j] = iBoard[u][j];
                                    iBoard[u][j] = 0;
                                }
                                u++;
                            }


                        }
                    }
                }

            }
            else if (key == KeyCode.Down)
            {
                for (int i = (iBoard.Count()- 1); i >=0; i--)
                {
                    for (int j = 0; j < iBoard.Count(); j++)
                    {
                        if (iBoard[i][j] > 0)
                            continue;
                        if (iBoard[i][j] == 0)
                        {
                            int u = i;


                            while (u < iBoard.Count() && u>=0)
                            {
                                if (iBoard[i][j] > 0)
                                    break;
                                if (iBoard[u][j] > 0)
                                {

                                    iBoard[i][j] = iBoard[u][j];
                                    iBoard[u][j] = 0;
                                }
                                u--;
                            }


                        }
                    }
                }

            }

            return iBoard;
        }
        private static int[][] WriteDefault()
        {
            rd = new Random();
            for (int i = 0; i < 2; i++)
            {
                int px = rd.Next(0, 4);
                int py = rd.Next(0, 4);

                if (iBoard[px][py] == 0)
                {
                    iBoard[px][py] = rd.Next(0, 20) == 0 ? rd.Next(0, 15) == 0 ? 8 : 4 : 2;

                    int c = rd.Next(0, 20);
                    int g = rd.Next(0, 15);
                }
            }
            
            return iBoard;
        }
    }
}
