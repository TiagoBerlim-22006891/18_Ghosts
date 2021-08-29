using System;
using System.Text;

namespace _18_Ghosts
{
    /// <summary>
    /// Class Inicial
    /// </summary>
    class Program
    {
        /// <summary>
        /// Inicializa o programa
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Suporte para caracteres unicode
            Console.OutputEncoding = Encoding.UTF8;

            // Declara e inicializa uma nova instancia de Menu
            Menu menu = new Menu();

            // Inicializa o menu
            menu.Init();
        }
    }
}
