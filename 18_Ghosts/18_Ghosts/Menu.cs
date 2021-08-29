using System;

namespace _18_Ghosts
{
    /// <summary>
    /// Class Menu
    /// </summary>
    class Menu
    {
        private Renderer render;
        private Game game;

        /// <summary>
        /// Construtor para a class menu
        /// </summary>
        public Menu()
        {
            render = new Renderer();
            game = new Game(render);
        }

        /// <summary>
        /// Inicializa o menu e pede uma escolha ao jogador
        /// </summary>
        public void Init()
        {
            render.RenderMenu();

            CheckPlayerChoice(Console.ReadKey(true).Key);
        }

        /// <summary>
        /// Verifica a escolha do jogador
        /// </summary>
        /// <param name="choice">Escolha realizada pelo jogador</param>
        private void CheckPlayerChoice(ConsoleKey choice)
        {
            //brief Se o jogador escolheu 1
            if (choice == ConsoleKey.D1 || choice == ConsoleKey.NumPad1) 
            {
                //brief Iniciamos o jogo
                game.Init();
            }
            else if (choice == ConsoleKey.D2 || choice == ConsoleKey.NumPad2)
            {
                //brief Se escolheu 2 saimos do jogo
                Environment.Exit(0);
            }

            //brief Volta ao menu inicial
            Init();
        }
    }
}
