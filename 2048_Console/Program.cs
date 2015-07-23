using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048_Console
{
    public enum KeyCode : int
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

    class Program
    {
        private static int[][] Tiles;

        static void Main(string[] args)
        {
            Tiles = new int[4][];

            for (int i = 0; i < 4; i++)
            {
                Tiles[i] = new int[4];
            }
            KeyCode key = new KeyCode();
            gameEngine engine = new gameEngine(Tiles);
            engine.runGame(key);
        }

    }
}
