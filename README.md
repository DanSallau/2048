# 2048
2048 GAME

A small clone of <a href="https://play.google.com/store/apps/details?id=com.veewo.a1024">1024, based on <a href="http://saming.fr/p/2048/">Samsung's 2048<a>(also a clone).

I made this project to satisfy the interview requirement at Mindvalley Malaysia Sdn Bhd . You can play the online version <a href="http://gabrielecirulli.github.io/2048/">Here</a> as developed by GabrielEcirulli.

# ScreenShot

Initial srceen before game start.

<a href="http://imgur.com/ftvhLlJ"><img src="http://i.imgur.com/ftvhLlJ.jpg" title="Hosted by imgur.com" /></a>

After game Start 

<a href="http://imgur.com/bWUBFd5"><img src="http://i.imgur.com/bWUBFd5.jpg?1" title="source: imgur.com" /></a>

# Design Flow 

The design follows the Object Oriented design. The game has four important steps or input. LEFT , RIGHT, UP, DOWN all similar steps in different directions. The same actions flow  takes place regardless of which step is pressed or followed. The  Tiles are first arrange in order, Then Similar tiles are merge, Tiles are rearrage in order again and then finally new tiles are added. Therefore, in our design these actions flow belong in a single base class 'gameManager'. The game manager is in turn inherited by the gameEngine class. The game engine class invoke the relavant actions and called upon the gameManager to perform  base on the key pressed . The code flow is shown below

gameManager.cs
<pre>
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
      

</pre>

And the child class gameEngine.cs

<pre>

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
            // controllers
        }
        
    }    

</pre>


# Contribution

The project is solely developed and maintained by Nuru Salihu Abdullahi
