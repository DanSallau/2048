using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048_Console
{
    class gameManager
    {
        private int[][] Tiles;
        private TilesCl tile;
        private DrawGame draw;
        public gameManager(int[][] tiles)
        {
            Tiles = tiles;
            tile = new TilesCl(tiles);
            draw = new DrawGame(tiles);
        }
        public virtual void runGame(KeyCode key)
        {
            //Arrange the tiles  upward
            tile.rearrangeTiles(key);
            //merge the resulting tiles where similar
            tile.mergeTiles(key);
            //Rearrange the tiles 
            tile.rearrangeTiles( key);
            //Add New Tile
            tile.addTile();
            draw.writeTiles(Tiles);
           // Console.Write(cki.Key.ToString());
            //Renew KeyBoard Listener
            
        }
       
       
        
    }
}
