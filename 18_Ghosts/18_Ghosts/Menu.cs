using System;

namespace _18_Ghosts
{
    class Menu
    {
        private Renderer render;
        private Game game;

        public Menu()
        {
            render = new Renderer();
            game = new Game(render);
        }

        public void Init()
        {
            render.RenderMenu();

            CheckPlayerChoice(Console.ReadKey(true).Key);
        }

        private void CheckPlayerChoice(ConsoleKey choice)
        {
            if (choice == ConsoleKey.D1 || choice == ConsoleKey.NumPad1) 
            {
                game.Init();
            }
            else if (choice == ConsoleKey.D2 || choice == ConsoleKey.NumPad2)
            {
                Environment.Exit(0);
            }

            Init();
        }
    }
}
