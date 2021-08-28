using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Ghosts
{
    class Renderer
    {
        public Renderer() {}

        public void RenderMenu()
        {
            Console.Clear();

            // Title
            Console.WriteLine("\n");
            Console.WriteLine(@"  __  ___     _____ _               _       ");
            Console.WriteLine(@" /_ |/ _ \   / ____| |             | |      ");
            Console.WriteLine(@"  | | (_) | | |  __| |__   ___  ___| |_ ___ ");
            Console.WriteLine(@"  | |> _ <  | | |_ | '_ \ / _ \/ __| __/ __|");
            Console.WriteLine(@"  | | (_) | | |__| | | | | (_) \__ \ |_\__ \");
            Console.WriteLine(@"  |_|\___/   \_____|_| |_|\___/|___/\__|___/");

            // Options
            Console.WriteLine("\n");
            Console.WriteLine("\t  ---------------------");
            Console.WriteLine("\t  |                   |");
            Console.WriteLine("\t  |     1 - Play      |");
            Console.WriteLine("\t  |     2 - Quit      |");
            Console.WriteLine("\t  |                   |");
            Console.WriteLine("\t  ---------------------");
        }

        public void RenderBoard(Tile[,] board)
        {
            Console.Clear();
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    Console.SetCursorPosition(x, y);

                    if (board[y, x].TileColor != ConsoleColor.Black)
                    {
                        Console.ForegroundColor = board[y, x].TileColor;
                    }

                    if (board[y, x].TileGhost != null)
                    {
                        Console.ForegroundColor = board[y, x].TileGhost.GhostColor;
                        Console.Write(board[y, x].TileGhost.Sprite);
                    }
                    else
                    {
                        Console.Write(board[y, x].Sprite);
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.ReadKey();
            Console.ReadKey();
        }

        public void GhostToMove(char axis)
        {
            Console.WriteLine($"What's the {axis} position of the ghost you want to control?");
        }

        public void ErrorMessage()
        {
            Console.WriteLine("That input is not valid. Try Again...");
        }

        public void MoveGhost()
        {
            Console.WriteLine("Use the arrow keys to move your ghost...");
        }

        public void RenderWinner(int winCondition)
        {
            switch (winCondition)
            {
                case 1:
                    Console.WriteLine("!!! PLAYER 1 WON !!!");
                    break;
                case 2:
                    Console.WriteLine("!!! PLAYER 2 WON !!!");
                    break;
                case 3:
                    Console.WriteLine("!!! IT'S A TIE !!!");
                    break;
            }
        }
    }
}
