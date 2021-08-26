using System;
using System.Collections.Generic;
using System.Linq;
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
            // Inicializar a board 
            board[0, 0] = new Tile("╔", ConsoleColor.Blue);
            board[0, 1] = new Tile("╦", ConsoleColor.Red);
            board[0, 2] = new Tile(ConsoleColor.Red, TileOrientation.Up);
            board[0, 3] = new Tile("╦", ConsoleColor.Blue);
            board[0, 4] = new Tile("╗", ConsoleColor.Red);

            board[1, 0] = new Tile("╠", ConsoleColor.Yellow);
            board[1, 1] = new Tile("A", ConsoleColor.Black, true);
            board[1, 2] = new Tile("╬", ConsoleColor.Yellow);
            board[1, 3] = new Tile("A", ConsoleColor.Black, true);
            board[1, 4] = new Tile("╣", ConsoleColor.Yellow);
                                     
            board[2, 0] = new Tile("╠", ConsoleColor.Red);
            board[2, 1] = new Tile("╬", ConsoleColor.Blue);
            board[2, 2] = new Tile("╬", ConsoleColor.Red);
            board[2, 3] = new Tile("╬", ConsoleColor.Blue);
            board[2, 4] = new Tile(ConsoleColor.Yellow, TileOrientation.Right);

            board[3, 0] = new Tile("╠", ConsoleColor.Blue);
            board[3, 1] = new Tile("A", ConsoleColor.Black, true);
            board[3, 2] = new Tile("╬", ConsoleColor.Yellow);
            board[3, 3] = new Tile("A", ConsoleColor.Black, true);
            board[3, 4] = new Tile("╣", ConsoleColor.Red);
                                   
            board[4, 0] = new Tile("╚", ConsoleColor.Yellow);
            board[4, 1] = new Tile("╩", ConsoleColor.Red);
            board[4, 2] = new Tile(ConsoleColor.Blue, TileOrientation.Down);
            board[4, 3] = new Tile("╩", ConsoleColor.Blue);
            board[4, 4] = new Tile("╝", ConsoleColor.Yellow);
            /*
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    if (new int[] {00, 30, 12, 32, 03, 24, 34}.Contains(Convert.ToInt32(string.Format("{0}{1}", x, y))))
                    {
                        board[y, x] = x == 2 && y == 4 ? new Tile(ConsoleColor.Blue, TileOrientation.Down) : new Tile(ConsoleColor.Blue);
                    }
                    else if (new int[] { 10, 20, 40, 02, 22, 43, 14 }.Contains(Convert.ToInt32(string.Format("{0}{1}", x, y))))
                    {
                        board[y, x] = x == 2 && y == 0 ? new Tile(ConsoleColor.Red, TileOrientation.Up) : new Tile(ConsoleColor.Red);
                    }
                    else if (new int[] { 01, 21, 41, 42, 23, 04, 44 }.Contains(Convert.ToInt32(string.Format("{0}{1}", x, y))))
                    {
                        board[y, x] = x == 4 && y == 2 ? new Tile(ConsoleColor.Yellow, TileOrientation.Left) : new Tile(ConsoleColor.Yellow);
                    }
                    else
                    {
                        board[y, x] = new Tile(ConsoleColor.Black, true);
                    }
                }
            }
            */
            render.RenderBoard(board);
        }

        private void GameLoop()
        {

        }

    }
}
