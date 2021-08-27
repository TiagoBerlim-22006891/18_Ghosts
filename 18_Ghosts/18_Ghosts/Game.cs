using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _18_Ghosts
{
    class Game
    {
        private Random rand;

        private Renderer render;

        private Tile[,] board;
        private List<Ghost> dungeon;

        private Player playerOne;
        private Player playerTwo;

        private bool gameOver;

        public Game(Renderer render)
        {
            this.render = render;
            
            board = new Tile[5, 5];

            dungeon = new List<Ghost>();

            gameOver = false;

            rand = new Random();
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
            
            playerOne = new Player(PlayerType.A);
            playerTwo = new Player(PlayerType.B);

            PlaceGhosts();

            GameLoop();
        }

        private void GameLoop()
        {
            do
            {
                // Dar render ao tabuleiro
                render.RenderBoard(board);



            } while (!gameOver);
        }

        private void PlaceGhosts()
        {
            Player currentPlaying;

            bool ghostPlaced = false;

            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    if (board[y, x].isExitTile || board[y, x].isMirrorTile)
                    {
                        continue;
                    }

                    currentPlaying = rand.NextDouble() < 0.5 ? playerOne : playerTwo;
                    
                    foreach( Ghost ghost in currentPlaying.Ghosts)
                    {
                        if (ghost.GhostColor == board[y, x].TileColor && !ghost.InGame)
                        {
                            ghost.InGame = true;
                            board[y, x].TileGhost = ghost;
                            ghostPlaced = true;
                            break;
                        }
                    }

                    if (!ghostPlaced)
                    {
                        currentPlaying = currentPlaying == playerOne ? playerTwo : playerOne;
                        
                        foreach (Ghost ghost in currentPlaying.Ghosts)
                        {
                            if (ghost.GhostColor == board[y, x].TileColor && !ghost.InGame)
                            {
                                ghost.InGame = true;
                                board[y, x].TileGhost = ghost;
                                break;
                            }
                        }
                    }

                    ghostPlaced = false;
                }
            }
        }

    }
}
