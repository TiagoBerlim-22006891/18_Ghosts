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

        public void ChoosePlay()
        {
            Console.WriteLine("(F - Free Ghost; M - Move Ghost)");
            Console.WriteLine("Do you want to Move a Ghost or Free a Ghost from the Dungeon?");
        }

        public void ErrorMessage()
        {
            Console.WriteLine("That input is not valid. Try Again...");
        }

        public void MoveGhost()
        {
            Console.WriteLine("Use the arrow keys to move your ghost...");
        }

        public void PlaceGhost(ConsoleColor color)
        {
            Console.WriteLine($"You have a {color} Ghost, it must be place on a {color} Tile...");
            Console.WriteLine($"What's the X position of the tile you want to place your ghost in?");
        }

        public void PlaceGhostY()
        {
            Console.WriteLine($"What's the Y position of the tile you want to place your ghost in?");
        }

        public void ChooseColorToFree(List<ConsoleColor> availableColors)
        {
            Console.Write("(");
            if (availableColors.Contains(ConsoleColor.Red))
            {
                Console.Write("R - Red; ");
            }
            if (availableColors.Contains(ConsoleColor.Blue))
            {
                Console.Write("B - Blue; ");
            }
            if (availableColors.Contains(ConsoleColor.Yellow))
            {
                Console.Write("Y - Yellow;");
            }
            Console.WriteLine(")");

            Console.WriteLine("What's the color of the ghost you want to free?");
        }

        public void GhostWasFreed(ConsoleColor color)
        {
            Console.WriteLine($"Your {color} Ghost was freed!");
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
