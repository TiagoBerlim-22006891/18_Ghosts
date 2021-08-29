using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Ghosts
{
    class Player
    {
        public List<Ghost> Ghosts { get; private set; }

        // Quantos fantasmas já escaparam
        public int EscapedGhosts { get; set; }

        public PlayerType Type { get; }
        
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
