using System;

namespace _18_Ghosts
{
    class Menu
    {
        private Renderer render;

        public Menu()
        {
            render = new Renderer();
        }

        public void Init()
        {
            render.DrawMenu();

            CheckPlayerChoice(Console.ReadKey(true).Key);
        }

        private void CheckPlayerChoice(ConsoleKey choice)
        {
            if (choice == ConsoleKey.D1 || choice == ConsoleKey.NumPad1) 
            {

            }
            else if (choice == ConsoleKey.D2 || choice == ConsoleKey.NumPad2)
            {
                Environment.Exit(0);
            }

            Init();
        }
    }
}
