using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Ghosts
{
    class Game
    {
        private Renderer render;

        private Tile[,] board;
        private List<Ghost> dungeon;

        public Game(Renderer render)
        {
            this.render = render;
            
            board = new Tile[5, 5];

            dungeon = new List<Ghost>();
        }

        public void Init()
        {

        }

    }
}
