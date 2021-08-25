using System;

namespace _18_Ghosts
{
    class Program
    {
        static Menu menu;

        static void Main(string[] args)
        {
            menu = new Menu();

            menu.Init();

            Console.ReadKey();
        }
    }
}
