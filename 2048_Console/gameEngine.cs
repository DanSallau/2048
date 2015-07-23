using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048_Console
{
    class gameEngine : gameManager
    {
        private int[][] Tiles;
        private DrawGame draw;
        public gameEngine(int[][] tiles):base(tiles)
        {
            Tiles = tiles;
            draw = new DrawGame(tiles);
        }
        public override void runGame(KeyCode k)
        {
            ConsoleKeyInfo cki;
            KeyCode key;
            // Prevent example from ending if CTL+C is pressed.
            Console.TreatControlCAsInput = true;

            Tiles = draw.WriteDefault();
            draw.writeTiles(Tiles);

            cki = Console.ReadKey();

            if (cki.Key == ConsoleKey.Enter)
            {
                GameModel.isAuthorized = true;
                GameModel.isGameOver = false;
                GameModel.Score = 0;
                draw.writeTiles(Tiles);
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
                        GameModel.isAuthorized = true;
                        GameModel.isGameOver = false;
                        GameModel.Score = 0;
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
                    base.runGame(KeyCode.Down);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(cki.Key.ToString());
                    cki = Console.ReadKey();
                }
                else if (cki.Key == ConsoleKey.UpArrow)
                {
                    base.runGame(KeyCode.Up);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(cki.Key.ToString());
                    cki = Console.ReadKey();
                }
                else if (cki.Key == ConsoleKey.LeftArrow)
                {
                    base.runGame(KeyCode.Left);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(cki.Key.ToString());
                    cki = Console.ReadKey();
                }
                else if (cki.Key == ConsoleKey.RightArrow)
                {
                    base.runGame(KeyCode.Right);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(cki.Key.ToString());
                    cki = Console.ReadKey();
                }

            } while (cki.Key != ConsoleKey.Escape && (GameModel.isAuthorized == true));


        }
    }
}
