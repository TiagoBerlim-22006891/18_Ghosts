using System;
using System.Text;

namespace _18_Ghosts
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Menu menu = new Menu();

            menu.Init();
        }
    }
}
