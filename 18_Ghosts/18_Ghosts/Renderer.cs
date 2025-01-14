﻿using System;
using System.Collections.Generic;

namespace _18_Ghosts
{
    /// <summary>
    /// Class Renderer responsavel por dar render a tudo no jogo
    /// </summary>
    class Renderer
    {
        // Indica o X e Y na consola
        int consoleX;
        int consoleY;

        /// <summary>
        /// Construtor de Renderer
        /// </summary>
        public Renderer() 
        {
            consoleX = 0;
            consoleY = 0;
        }

        /// <summary>
        /// Da render ao menu do jogo
        /// </summary>
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

        /// <summary>
        /// Da render a scene do jogo
        /// </summary>
        /// <param name="board">Referencia para o tabuleiro de jogo</param>
        /// <param name="dungeon">Referencia para a dungeon</param>
        /// <param name="currentPlayer">Referencia para o jogador actual</param>
        public void RenderScene(Tile[,] board, List<Ghost> dungeon, Player currentPlayer)
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine(" ________________________________________________");
            Console.WriteLine("|       |       |       |       |       |        |");
            Console.WriteLine("|       |       |       |       |       |        |");
            Console.WriteLine("|_______|_______|_______|_______|_______|        |");
            Console.WriteLine("|       |       |       |       |       |        |");
            Console.WriteLine("|       |       |       |       |       |        |");
            Console.WriteLine("|_______|_______|_______|_______|_______|        |");
            Console.WriteLine("|       |       |       |       |       |        |");
            Console.WriteLine("|       |       |       |       |       |        |");
            Console.WriteLine("|_______|_______|_______|_______|_______|        |");
            Console.WriteLine("|       |       |       |       |       |        |");
            Console.WriteLine("|       |       |       |       |       |        |");
            Console.WriteLine("|_______|_______|_______|_______|_______|        |");
            Console.WriteLine("|       |       |       |       |       |        |");
            Console.WriteLine("|       |       |       |       |       |        |");
            Console.WriteLine("|_______|_______|_______|_______|_______|________|");

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

            // Local em X da dungeon para desenhar os fantasmas
            int dungeonX = 43;
            int yCounter = 1;

            for (int i = 0; i < dungeon.Count; i++)
            {
                Console.SetCursorPosition(dungeonX, yCounter * 3);
                Console.ForegroundColor = dungeon[i].GhostColor;
                Console.Write(dungeon[i].Sprite);

                dungeonX = dungeonX == 43 ? 46 : 43;

                if (i % 2 != 0)
                {
                    yCounter++;
                }
            }

            ResetForeground();

            HelpMenu();
            PlayerStats(currentPlayer);
        }

        /// <summary>
        /// Da render a uma legenda lateral com algumas informações de ajuda
        /// </summary>
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

        /// <summary>
        /// Da render as stats do jogador actual
        /// </summary>
        /// <param name="currentPlayer">Referencia para o jogador actual</param>
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

        /// <summary>
        /// Pede ao jogador que fantasma ele quer mexer
        /// </summary>
        /// <param name="axis">O axis em que o fantasma vai mexer (X ou Y)</param>
        public void GhostToMove(char axis)
        {
            Console.WriteLine($"\nWhat's the {axis} position of the ghost you want to control?");
        }

        /// <summary>
        /// Pergunta ao jogador se ele quer mover ou libertar um fantasma
        /// </summary>
        public void ChoosePlay()
        {
            Console.WriteLine("(F - Free Ghost; M - Move Ghost)");
            Console.WriteLine("Do you want to Move a Ghost or Free a Ghost from the Dungeon?");
        }

        /// <summary>
        /// Mostra uma mensagem de erro ao jogador
        /// </summary>
        public void ErrorMessage()
        {
            Console.WriteLine("\nThat input is not valid. Try Again...");
        }

        /// <summary>
        /// Informa o jogador de como ele pode mover o fantasma
        /// </summary>
        public void MoveGhost()
        {
            Console.WriteLine("\nUse the arrow keys to move your ghost...");
        }

        /// <summary>
        /// Pede ao jogador o X no tabuleiro do fantasma a jogar
        /// </summary>
        /// <param name="color">A cor da sala em que o fantasma tem que ser jogado</param>
        public void PlaceGhost(ConsoleColor color)
        {
            Console.WriteLine($"You have a {color} Ghost, it must be place on a {color} Tile...");
            Console.WriteLine($"What's the X position of the tile you want to place your ghost in?");
        }

        /// <summary>
        /// Pede ao jogador o Y no tabuleiro do fantasma a jogar
        /// </summary>
        public void PlaceGhostY()
        {
            Console.WriteLine($"\nWhat's the Y position of the tile you want to place your ghost in?");
        }

        /// <summary>
        /// Pergunta ao jogador que cor de fantasma ele quer libertar
        /// </summary>
        /// <param name="availableColors"></param>
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

        /// <summary>
        /// Informa o jogador de que o fantasma foi liberto
        /// </summary>
        /// <param name="color"></param>
        public void GhostWasFreed(ConsoleColor color)
        {
            Console.WriteLine($"Your {color} Ghost was freed!");
        }

        /// <summary>
        /// Informa que jogador ganhou o jogo
        /// </summary>
        /// <param name="winCondition">A condição de vitoria</param>
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

        /// <summary>
        /// Reset da cor da consola para branco
        /// </summary>
        private void ResetForeground() => Console.ForegroundColor = ConsoleColor.White;
    }
}
