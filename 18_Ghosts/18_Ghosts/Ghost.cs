using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Ghosts
{
    class Ghost
    {
        public char Sprite { get; }

        public Player Owner { get; }

        public Color GhostColor { get; }

        public Ghost(Player owner, Color color)
        {
            Owner = owner;

            GhostColor = color;

            Sprite = Owner == Player.A ? 'M' : 'W';
        }
    }
}
