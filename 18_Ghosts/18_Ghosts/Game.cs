using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _18_Ghosts
{
    /// <summary>
    /// Class responsavel pela loop e mecanicas do jogo
    /// </summary>
    class Game
    {
        // Random para colocação automática de peças
        private Random rand;

        // Referencia para o renderer do jogo
        private Renderer render;

        // Array multidimencional que serve de tabuleiro para o jogo
        private Tile[,] board;
        // A dungeon para onde os fantasmas comidos vão
        private List<Ghost> dungeon;
        // As cores de fantasmas que estão disponivei para sairem da dungeon
        private List<ConsoleColor> availableColor;

        // O jogador que esta a jogar no turno actual
        private Player currentPlayer;
        // O Jogador A
        private Player playerOne;
        // O Jogador B
        private Player playerTwo;

        // A condição de vitoria (1 - Ganha jogador A; 2 - Ganha jogador B; 3 - Empate)
        private int winCondition;

        // Se o jogador escolheu libertar um fantasma
        private bool chooseFreeGhost;
        // Se a opção escolhida pelo jogador é valida
        private bool validChoice;

        // Posição x e y actual
        private int xPos;
        private int yPos;

        /// <summary>
        /// Construtor para a class Game
        /// </summary>
        /// <param name="render">Referencia para o renderer do jogo</param>
        public Game(Renderer render)
        {
            // Guarda a referencia para o render
            this.render = render;
            
            // Inicializa o tabuleiro de jogo
            board = new Tile[5, 5];

            // Inicializa a lista de fantasmas na dungeon
            dungeon = new List<Ghost>();

            // Inicializa a lista de cores disponiveis
            availableColor = new List<ConsoleColor>();

            // Inicializa o random
            rand = new Random();
        }

        /// <summary>
        /// Inicializa o jogo colocando todas as devidas peças no
        /// lugar certa para o jogo poder ser jogado
        /// </summary>
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
            
            // Inicializa o jogador A e B
            playerOne = new Player(PlayerType.A);
            playerTwo = new Player(PlayerType.B);

            // Inicializa o 'currentPlayer' com o jogador A para o 1º turno
            currentPlayer = playerOne;

            // Inicializa a escolha de libertar um fantasma a falso por defeito
            chooseFreeGhost = false;

            // Coloca todos os fantasmas no tabuleiro
            PlaceGhosts();

            // Responsavel por fazer loop ao jogo até existir uma condição de vitoria
            GameLoop();
        }

        /// <summary>
        /// Responsavel por fazer loop ao jogo até existir uma condição de vitoria
        /// </summary>
        private void GameLoop()
        {
            // Game Loop
            do
            {
                // Dar render ao tabuleiro
                render.RenderScene(board, dungeon, currentPlayer);

                // Quando o jogador tem fantasmas para jogar é obrigado a faze-lo
                if (currentPlayer.Ghosts.Count != 0)
                {
                    // Dar reset de escolha valida para falso
                    validChoice = false;

                    // Da loop até o jogador realizar uma escolha válida
                    do
                    {
                        // Pedimos ao jogador o X da casa em que ele quer colocar o fantasma
                        render.PlaceGhost(currentPlayer.Ghosts[0].GhostColor);

                        // Guardamos o valor caso valido
                        xPos = UpdateXY();

                        // Pedimos ao jogador o Y da casa em que ele quer colocar o fantasma
                        render.PlaceGhostY();

                        // Guardamos o valor caso valido
                        yPos = UpdateXY();

                        // Se a casa é valida
                        if (board[yPos, xPos].TileGhost == null && board[yPos, xPos].TileColor == currentPlayer.Ghosts[0].GhostColor)
                        {
                            // O jogador fez uma escolha valida
                            validChoice = true;
                        }
                        else
                        {
                            // Se não damos mensagem de erro
                            render.ErrorMessage();
                        }

                    } while (!validChoice);

                    // Coloca-se o fantasma na casa escolhida
                    board[yPos, xPos].TileGhost = currentPlayer.Ghosts[0];
                    // Remove-se o fantasma do jogador
                    currentPlayer.Ghosts.RemoveAt(0);
                }
                // Se não tem fantasmas para jogar
                else
                {
                    // String para guardar a escolha do jogador
                    string choice;

                    // Se existir um fantasma na dungeon com oportunidade de ser libertado
                    if (dungeon.Count != 0 && CheckFreeableGhost())
                    {
                        // Executa até o jogador fazer uma escolha válida
                        do
                        {
                            // Perguntamos ao jogador se ele quer libertar ou mover um fantasma
                            render.ChoosePlay();

                            // Le a escolha do jogador
                            choice = Console.ReadLine();
                            choice = choice.ToLower();

                            // Se a escolha não for valida
                            if (choice != "f" && choice != "m")
                            {
                                // Manda mensagem de erro
                                render.ErrorMessage();
                            }
                        } while (choice != "f" && choice != "m");

                        // Guardamos se o jogador escolheu ou não libertar um fantasma
                        chooseFreeGhost = choice == "f";
                    }

                    // Se o jogador escolher mover um fantasma ou se não houver fantasmas na dungeon
                    if (dungeon.Count == 0 || !chooseFreeGhost)
                    {
                        // Executa até o jogador fazer uma escolha válida
                        do
                        {
                            // Pede ao utilizador a localização do fantasma que ele quer mover
                            render.GhostToMove('X');

                            // Da update à posição selecionada pelo jogador
                            xPos = UpdateXY();

                            // Pede ao utilizador a localização em Y do fantasma que ele quer mexer
                            render.GhostToMove('Y');

                            // Da update à posição selecionada pelo jogador
                            yPos = UpdateXY();

                        } while (!CheckHouse());

                        // Movimentamos o fantasma
                        MoveGhost();
                    }
                    // Se o jogador escolheu libertar um fantasma
                    else if (chooseFreeGhost)
                    {
                        // Da reset a escolha de libertar
                        chooseFreeGhost = false;
                        // Da reset a escolha ser valida
                        validChoice = false;

                        // Executa até o jogador fazer uma escolha válida
                        do
                        {
                            // Pede-se o jogador para esolher uma das cores validas para libertar
                            render.ChooseColorToFree(availableColor);

                            // Le a escolha do jogador
                            choice = Console.ReadLine();
                            choice = choice.ToLower();

                            switch (choice)
                            {
                                case "r":
                                    if (availableColor.Contains(ConsoleColor.Red))
                                    {
                                        // Liberta-se o fantasma vermelho da dungeon
                                        FreeGhostFromDungeon(ConsoleColor.Red);
                                        validChoice = true;
                                    }
                                    break;
                                case "b":
                                    if (availableColor.Contains(ConsoleColor.Blue))
                                    {
                                        // Liberta-se o fantasma azul da dungeon
                                        FreeGhostFromDungeon(ConsoleColor.Blue);
                                        validChoice = true;
                                    }
                                    break;
                                case "y":
                                    if (availableColor.Contains(ConsoleColor.Yellow))
                                    {
                                        // Liberta-se o fantasma amarelo da dungeon
                                        FreeGhostFromDungeon(ConsoleColor.Yellow);
                                        validChoice = true;
                                    }
                                    break;
                                default:
                                    // Se a escolha não for valida mostra a mensagem de erro
                                    render.ErrorMessage();
                                    break;
                            }

                        } while (!validChoice);

                        // Espera um input extra para terminar o turno
                        Console.ReadKey(true);
                    }
                }

                // Verifica se existe algum fantasma com a possibilidade de escapar
                CheckPortalRotation();

                // Se o jogador A tiver 3 ou mais fantasmas fora
                if (playerOne.EscapedGhosts >= 3)
                {
                    // O jogador A ganha
                    winCondition = 1;
                }
                // Se o jogador B tiver 3 ou mais fantasmas fora
                if (playerTwo.EscapedGhosts >= 3)
                {
                    // O jogador B ganha caso o jogador A não tenha mais de 3 tambem,
                    // Se tiver é empate
                    winCondition = winCondition == 1 ? 3 : 2;
                }

                // Muda o jogador actual
                currentPlayer = currentPlayer == playerOne ? playerTwo : playerOne;

            } while (winCondition == 0);

            // Mostra quem ganhou o jogo
            render.RenderWinner(winCondition);
            // Espera um input para volta ao menu
            Console.ReadKey();
        }

        /// <summary>
        /// Liberta um fantasma de certa cor da dungeon
        /// </summary>
        /// <param name="color">Cor do fantasma a libertar</param>
        private void FreeGhostFromDungeon(ConsoleColor color)
        {
            // Percorre todos os fantasmas na dungeon
            for (int i = 0; i < dungeon.Count; i++)
            {
                // Se for possivel libertar o fantasma
                if (dungeon[i].GhostColor == color && dungeon[i].Owner == currentPlayer.Type)
                {
                    // Verifica que jogador vai ter que o jogar no proximo turno
                    if (currentPlayer.Type == PlayerType.A)
                    {
                        playerTwo.Ghosts.Add(dungeon[i]);
                        dungeon.RemoveAt(i);
                        render.GhostWasFreed(color);
                        break;
                    }
                    else
                    {
                        playerOne.Ghosts.Add(dungeon[i]);
                        dungeon.RemoveAt(i);
                        render.GhostWasFreed(color);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Verifica se existe algum fantasma do jogador actual que posse ser libertado da dungeon
        /// </summary>
        /// <returns>Verdadeiro ou Falso caso exista ou não um fantasma para ser liberto</returns>
        private bool CheckFreeableGhost()
        {
            bool freeable = false;

            // Reset as cores disponiveis para libertação
            availableColor.Clear();

            // Percorre o tabuleiro
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    // Se a casa actual tiver vazia
                    if (board[y, x].TileGhost == null && !board[y, x].isExitTile && !board[y, x].isMirrorTile)
                    {
                        // Percorre a dungeon
                        for (int i = 0; i < dungeon.Count; i++)
                        {
                            // Se o fantasma actual pertencer ao jogador actual e tiver a mesma cor que a casa vazia
                            if (dungeon[i].Owner == currentPlayer.Type &&
                                dungeon[i].GhostColor == board[y, x].TileColor)
                            {
                                if (availableColor.Count == 0 || !availableColor.Contains(dungeon[i].GhostColor))
                                {
                                    // Adicionamos a lista de cores de fantasmas que pode ser libertos
                                    availableColor.Add(dungeon[i].GhostColor);
                                }
                                // Pode-se libertar um fantasma este turno
                                freeable = true;
                            }
                        }
                    }
                }
            }

            return freeable;
        }

        /// <summary>
        /// Verificamos se o fantasma pode escapar
        /// </summary>
        /// <param name="x">Localizção em X do fantasma que vai escapar</param>
        /// <param name="y">Localizção em Y do fantasma que vai escapar</param>
        /// <param name="color">A Cor do fantasma que vai escapar</param>
        private void GhostTryEscape(int x, int y, ConsoleColor color)
        {
            if (board[y, x].TileGhost != null && board[y, x].TileGhost.GhostColor == color)
            {
                if (board[y, x].TileGhost.Owner == PlayerType.A)
                {
                    playerOne.EscapedGhosts++;
                }
                else
                {
                    playerTwo.EscapedGhosts++;
                }

                board[y, x].TileGhost = null;
            }
        }

        /// <summary>
        /// Verifica a rotação do portal para saber se algum fantasma pode escapar
        /// </summary>
        private void CheckPortalRotation()
        {
            // Verificar ao pe do portal vermelho
            switch (board[0, 2].Orientation)
            {
                case TileOrientation.Left:
                    GhostTryEscape(1, 0, ConsoleColor.Red);
                    break;
                case TileOrientation.Down:
                    GhostTryEscape(2, 1, ConsoleColor.Red);
                    break;
                case TileOrientation.Right:
                    GhostTryEscape(3, 0, ConsoleColor.Red);
                    break;
            }
            // Verificar ao pe do portal amarelo
            switch (board[2, 4].Orientation)
            {
                case TileOrientation.Up:
                    GhostTryEscape(4, 1, ConsoleColor.Yellow);
                    break;
                case TileOrientation.Left:
                    GhostTryEscape(3, 2, ConsoleColor.Yellow);
                    break;
                case TileOrientation.Down:
                    GhostTryEscape(4, 3, ConsoleColor.Yellow);
                    break;
            }
            // Verificar ao pe do portal azul
            switch (board[4, 2].Orientation)
            {
                case TileOrientation.Left:
                    GhostTryEscape(1, 4, ConsoleColor.Blue);
                    break;
                case TileOrientation.Up:
                    GhostTryEscape(2, 3, ConsoleColor.Blue);
                    break;
                case TileOrientation.Right:
                    GhostTryEscape(3, 4, ConsoleColor.Blue);
                    break;
            }
        }

        /// <summary>
        /// Da update ao X e Y selecionado pelo jogador (Pode referir a um Tile ou Fantasma)
        /// </summary>
        /// <returns>X ou Y decidido pelo jogador</returns>
        private int UpdateXY()
        {
            int keyInt;

            // Converte para string e remove todos os characteres que não estejam entre 0 e 4.
            while (!int.TryParse(Regex.Replace(Console.ReadKey().Key.ToString(), "[^0-4]", ""), out keyInt))
            {
                // Enquanto o input for incorreto mostrar uma mensagem de erro.
                render.ErrorMessage();
            }

            return keyInt;
        }

        /// <summary>
        /// Move um fantasma
        /// </summary>
        private void MoveGhost()
        {
            int x;
            int y;
            ConsoleKey key;

            render.MoveGhost();

            do
            {
                x = xPos;
                y = yPos;

                while (!(key = Console.ReadKey(true).Key).ToString().Contains("Arrow"))
                {
                    render.ErrorMessage();
                }

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                            y--;
                        break;
                    case ConsoleKey.DownArrow:
                            y++;
                        break;
                    case ConsoleKey.RightArrow:
                            x++;
                        break;
                    case ConsoleKey.LeftArrow:
                            x--;
                        break;
                }

                if (x > 4 || x < 0 || y > 4 || y < 0 || board[y, x].isExitTile || 
                    (board[y, x].TileGhost != null && 
                    board[y, x].TileGhost.GhostColor == board[yPos, xPos].TileGhost.GhostColor))
                {
                    render.ErrorMessage();
                }

            } while (x > 4 || x < 0 || y > 4 || y < 0 || board[y, x].isExitTile ||
                    (board[y, x].TileGhost != null && 
                    board[y, x].TileGhost.GhostColor == board[yPos, xPos].TileGhost.GhostColor));

            if (board[y, x].isMirrorTile)
            {
                x += 2;
                y += 2;
                x = x == 5 ? 1 : x;
                y = y == 5 ? 1 : y;

                if (board[y, x].TileGhost != null)
                {
                    GhostFight(x, y);
                }
                else
                {
                    board[y, x].TileGhost = board[yPos, xPos].TileGhost;
                }
            }
            else if (board[y, x].TileGhost != null)
            {
                GhostFight(x, y);
            }
            else
            {
                board[y, x].TileGhost = board[yPos, xPos].TileGhost;
            }

            board[yPos, xPos].TileGhost = null;
        }

        /// <summary>
        /// Resolve as lutas entre 2 fantasmas
        /// </summary>
        /// <param name="x">X do fantasma contra quem se vai lutar</param>
        /// <param name="y">Y do fantasma contra quem se vai lutar</param>
        public void GhostFight(int x, int y)
        {
            ConsoleColor myColor = board[yPos, xPos].TileGhost.GhostColor;
            ConsoleColor otherColor = board[y, x].TileGhost.GhostColor;

            switch (myColor)
            {
                case ConsoleColor.Red:
                    if (otherColor == ConsoleColor.Yellow)
                    {
                        dungeon.Add(board[yPos, xPos].TileGhost);
                        board[0, 2].Orientation++;
                    }
                    else
                    {
                        dungeon.Add(board[y, x].TileGhost);
                        board[y, x].TileGhost = board[yPos, xPos].TileGhost;
                        board[4, 2].Orientation++;
                    }
                    break;
                case ConsoleColor.Blue:
                    if (otherColor == ConsoleColor.Red)
                    {
                        dungeon.Add(board[yPos, xPos].TileGhost);
                        board[4, 2].Orientation++;
                    }
                    else
                    {
                        dungeon.Add(board[y, x].TileGhost);
                        board[y, x].TileGhost = board[yPos, xPos].TileGhost;
                        board[2, 4].Orientation++;
                    }
                    break;
                case ConsoleColor.Yellow:
                    if (otherColor == ConsoleColor.Blue)
                    {
                        dungeon.Add(board[yPos, xPos].TileGhost);
                        board[2, 4].Orientation++;
                    }
                    else
                    {
                        dungeon.Add(board[y, x].TileGhost);
                        board[y, x].TileGhost = board[yPos, xPos].TileGhost;
                        board[0, 2].Orientation++;
                    }
                    break;
            }
        }

        /// <summary>
        /// Verifica se a casa selecionada tem um fantasma do jogador
        /// </summary>
        /// <returns>Se a casa tem um fantasma ou não</returns>
        private bool CheckHouse() => 
            board[yPos, xPos].TileGhost != null && board[yPos, xPos].TileGhost.Owner == currentPlayer.Type;

        /// <summary>
        /// Coloca todos os fantasmas no tabuleiro
        /// </summary>
        private void PlaceGhosts()
        {
            Player currentPlaying;

            bool ghostPlaced;

            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    ghostPlaced = false;

                    if (board[y, x].isExitTile || board[y, x].isMirrorTile)
                    {
                        continue;
                    }

                    currentPlaying = rand.NextDouble() < 0.5 ? playerOne : playerTwo;

                    ghostPlaced = TryPlacing(currentPlaying, x, y);

                    if (!ghostPlaced)
                    {
                        currentPlaying = currentPlaying == playerOne ? playerTwo : playerOne;

                        TryPlacing(currentPlaying, x, y);
                    }
                }
            }
        }

        /// <summary>
        /// Verifica se é possivel colocar um fantasma no lugar indicado pelo jogador
        /// </summary>
        /// <param name="currentPlaying">O jogador actual</param>
        /// <param name="x">X da casa onde se quer colocar o fantasma</param>
        /// <param name="y">Y da casa onde se quer colocar o fantasma</param>
        /// <returns></returns>
        private bool TryPlacing(Player currentPlaying, int x, int y)
        {
            foreach (Ghost ghost in currentPlaying.Ghosts)
            {
                if (ghost.GhostColor == board[y, x].TileColor && !ghost.InGame)
                {
                    ghost.InGame = true;
                    board[y, x].TileGhost = ghost;
                    currentPlaying.Ghosts.Remove(ghost);
                    return true;
                }
            }
            return false;
        }

    }
}
