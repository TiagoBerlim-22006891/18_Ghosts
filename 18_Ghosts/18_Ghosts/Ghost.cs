using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Ghosts
{
    /// <summary>
    /// Class Ghost contem toda a informação sobre um fantasma
    /// </summary>
    class Ghost
    {
        /// <summary>
        /// A sprite do fantasma
        /// </summary>
        public char Sprite { get; }

        /// <summary>
        /// O dono do fantasma
        /// </summary>
        public PlayerType Owner { get; }

        /// <summary>
        /// A cor do fantasma
        /// </summary>
        public ConsoleColor GhostColor { get; }

        private bool inGame;
        /// <summary>
        /// Se o fantasma se encontra em jogo
        /// </summary>
        public bool InGame { 
            get => inGame; 
            set { 
                if (!inGame)
                {
                    inGame = value;
                }
            } 
        }

        /// <summary>
        /// Construtor pra Ghost
        /// </summary>
        /// <param name="owner">O dono do fantasma</param>
        /// <param name="color">A cor do fantasma</param>
        public Ghost(PlayerType owner, ConsoleColor color)
        {
            Owner = owner;

            GhostColor = color;

            Sprite = Owner == PlayerType.A ? '☺' : '☻';

            inGame = false;
        }
    }
}
