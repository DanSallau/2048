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
        private FileLogger obj;
        public gameManager(int[][] tiles)
        {
            //inject dependency and instantiations
            Tiles = tiles;
            tile = new TilesCl(tiles);
            draw = new DrawGame(tiles);
            obj = new FileLogger();
        }
        public virtual void runGame(KeyCode key)
        {
            try
            {
                //Arrange the tiles 
                tile.rearrangeTiles(key);
                //merge the resulting tiles where similar
                tile.mergeTiles(key);
                //Rearrange the tiles 
                tile.rearrangeTiles(key);
                //Add New Tile
                tile.addTile();
                draw.writeTiles(Tiles);
                // Console.Write(cki.Key.ToString());
                //Renew KeyBoard Listener
            }
            catch (Exception e)
            {
                obj.Handle(e.ToString());
            }
            
        }
       
       
        
    }
}
