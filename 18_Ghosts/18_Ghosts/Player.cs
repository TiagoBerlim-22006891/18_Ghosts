using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Ghosts
{
    class Player
    {
        public Ghost[] Ghosts { get; private set; }

        public PlayerType Type { get; }
        
        public Player(PlayerType type)
        {
            Type = type;
            Ghosts = new Ghost[9];

            InitializeGhosts();
        }

        private void InitializeGhosts()
        {
            for (int i = 0; i < Ghosts.Length; i++)
            {
                if (i < 3)
                {
                    Ghosts[i] = new Ghost(Type, ConsoleColor.Red);
                }
                else if (i < 6)
                {
                    Ghosts[i] = new Ghost(Type, ConsoleColor.Blue);
                }
                else
                {
                    Ghosts[i] = new Ghost(Type, ConsoleColor.Yellow);
                }
            }
        }
    }
}
