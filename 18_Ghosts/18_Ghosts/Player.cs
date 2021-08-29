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
        /// <summary>
        /// Lista de fantasmas que o jogador tem para jogar
        /// </summary>
        public List<Ghost> Ghosts { get; private set; }

        /// <summary>
        /// Quantos fantasmas já escaparam
        /// </summary>
        public int EscapedGhosts { get; set; }

        /// <summary>
        /// O tipo do jogador
        /// </summary>
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
