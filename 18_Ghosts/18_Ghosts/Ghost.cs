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
        // A sprite do fantasma
        public char Sprite { get; }

        // O dono do fantasma
        public PlayerType Owner { get; }

        // A cor do fantasma
        public ConsoleColor GhostColor { get; }

        // Se o fantasma se encontra em jogo
        private bool inGame;
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
