using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Ghosts
{
    class Player
    {
        public Ghost[] Ghosts { get; private set; }

        // Quantos fantasmas já escaparam
        public int EscapedGhosts { get; set; }

        public PlayerType Type { get; }
        
        public Player(PlayerType type)
        {
            Type = type;
            Ghosts = new Ghost[9];
            EscapedGhosts = 0;

            // Inicializar os fantasmas
            Ghosts[0] = new Ghost(Type, ConsoleColor.Red);
            Ghosts[1] = new Ghost(Type, ConsoleColor.Red);
            Ghosts[2] = new Ghost(Type, ConsoleColor.Red);
            Ghosts[3] = new Ghost(Type, ConsoleColor.Blue);
            Ghosts[4] = new Ghost(Type, ConsoleColor.Blue);
            Ghosts[5] = new Ghost(Type, ConsoleColor.Blue);
            Ghosts[6] = new Ghost(Type, ConsoleColor.Yellow);
            Ghosts[7] = new Ghost(Type, ConsoleColor.Yellow);
            Ghosts[8] = new Ghost(Type, ConsoleColor.Yellow);
        }
    }
}
