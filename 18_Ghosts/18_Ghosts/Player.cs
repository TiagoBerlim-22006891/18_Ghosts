using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Ghosts
{
    /// <summary>
    /// Class Player contem toda a informação sobre o jogador
    /// </summary>
    class Player
    {
        // Lista de fantasmas que o jogador tem para jogar
        public List<Ghost> Ghosts { get; private set; }

        // Quantos fantasmas já escaparam
        public int EscapedGhosts { get; set; }

        // O tipo do jogador
        public PlayerType Type { get; }
        
        /// <summary>
        /// Contrutor para o jogador Inicializa os fantasmas do jogador
        /// </summary>
        /// <param name="type">O Tipo do jogador (A ou B)</param>
        public Player(PlayerType type)
        {
            Type = type;
            Ghosts = new List<Ghost>();
            EscapedGhosts = 0;

            // Inicializar os fantasmas
            Ghosts.Add(new Ghost(Type, ConsoleColor.Red));
            Ghosts.Add(new Ghost(Type, ConsoleColor.Red));
            Ghosts.Add(new Ghost(Type, ConsoleColor.Red));
            Ghosts.Add(new Ghost(Type, ConsoleColor.Blue));
            Ghosts.Add(new Ghost(Type, ConsoleColor.Blue));
            Ghosts.Add(new Ghost(Type, ConsoleColor.Blue));
            Ghosts.Add(new Ghost(Type, ConsoleColor.Yellow));
            Ghosts.Add(new Ghost(Type, ConsoleColor.Yellow));
            Ghosts.Add(new Ghost(Type, ConsoleColor.Yellow));
        }
    }
}
