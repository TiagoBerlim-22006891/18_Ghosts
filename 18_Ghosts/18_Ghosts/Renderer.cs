using System;
using System.Collections.Generic;

namespace _18_Ghosts
{
    class Renderer
    {
        int consoleX;
        int consoleY;

        public Renderer() 
        {
            consoleX = 0;
            consoleY = 0;
        }

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

        public void RenderScene(Tile[,] board, Player currentPlayer)
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine(" _______________________________________________ ");
            Console.WriteLine("|       |       |       |       |       |       |");
            Console.WriteLine("|       |       |       |       |       |       |");
            Console.WriteLine("|_______|_______|_______|_______|_______|       |");
            Console.WriteLine("|       |       |       |       |       |       |");
            Console.WriteLine("|       |       |       |       |       |       |");
            Console.WriteLine("|_______|_______|_______|_______|_______|       |");
            Console.WriteLine("|       |       |       |       |       |       |");
            Console.WriteLine("|       |       |       |       |       |       |");
            Console.WriteLine("|_______|_______|_______|_______|_______|       |");
            Console.WriteLine("|       |       |       |       |       |       |");
            Console.WriteLine("|       |       |       |       |       |       |");
            Console.WriteLine("|_______|_______|_______|_______|_______|       |");
            Console.WriteLine("|       |       |       |       |       |       |");
            Console.WriteLine("|       |       |       |       |       |       |");
            Console.WriteLine("|_______|_______|_______|_______|_______|_______|");

            for (int y = 0; y < 5; y++)
            {
                
                consoleY = (y + 1) * 3;

                for (int x = 0; x < 5; x++)
                {
                    consoleX = (x * 2 + 1) * 4;

                    Console.SetCursorPosition(consoleX, consoleY);

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

                    ResetForeground();
                }
            }

            HelpMenu();
            PlayerStats(currentPlayer);
        }

        private void HelpMenu()
        {
            Console.SetCursorPosition(50, 2);
            Console.Write(" Carpet \t\t ║  ╔ ╗ ═ ╚ ╝ ╬ ╦ ╩ ╠ ╣ ");
            Console.SetCursorPosition(50, 4);
            Console.Write(" Portal \t\t Up ↑ | Down ↓ | Left ←  | Right → ");
            Console.SetCursorPosition(50, 6);
            Console.Write(" Mirror \t\t A ");
            Console.SetCursorPosition(50, 8);
            Console.Write(" Player A Ghost \t ☺ ");
            Console.SetCursorPosition(50, 10);
            Console.Write(" Player B Ghost \t ☻ ");
        }

        private void PlayerStats(Player currentPlayer)
        {
            Console.SetCursorPosition(50, 13);
            Console.Write(" Player Stats:");

            Console.SetCursorPosition(50, 15);
            Console.Write($" Current Player: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Player {currentPlayer.Type}");
            ResetForeground();

            Console.SetCursorPosition(50, 16);
            Console.Write($" Freed Ghosts: ");
            Console.ForegroundColor = currentPlayer.EscapedGhosts > 0 ?
                ConsoleColor.Green : ConsoleColor.Red;
            Console.Write(currentPlayer.EscapedGhosts);
            ResetForeground();

            Console.SetCursorPosition(0, 18);
        }

        public void GhostToMove(char axis)
        {
            Console.WriteLine($"\nWhat's the {axis} position of the ghost you want to control?");
        }

        public void ChoosePlay()
        {
            Console.WriteLine("(F - Free Ghost; M - Move Ghost)");
            Console.WriteLine("Do you want to Move a Ghost or Free a Ghost from the Dungeon?");
        }

        public void ErrorMessage()
        {
            Console.WriteLine("\nThat input is not valid. Try Again...");
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
            Console.WriteLine($"\nWhat's the Y position of the tile you want to place your ghost in?");
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

        private void ResetForeground() => Console.ForegroundColor = ConsoleColor.White;
    }
}
