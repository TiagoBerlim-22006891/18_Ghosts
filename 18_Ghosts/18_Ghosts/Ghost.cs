using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Ghosts
{
    class Ghost
    {
        public char Sprite { get; }

        public PlayerType Owner { get; }

        public ConsoleColor GhostColor { get; }

        public Ghost(PlayerType owner, ConsoleColor color)
        {
            Owner = owner;

            GhostColor = color;

            Sprite = Owner == PlayerType.A ? 'M' : 'W';
        }
    }
}
