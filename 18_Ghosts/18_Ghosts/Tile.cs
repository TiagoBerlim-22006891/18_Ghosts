using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Ghosts
{
    struct Tile
    {
        public ConsoleColor TileColor { get; }
        public TileOrientation Orientation { get; set; }

        public Ghost TileGhost { get; set; }

        private string sprite;
        public string Sprite {
            get
            {
                if (!isExitTile) return sprite;

                switch (Orientation)
                {
                    case TileOrientation.Up:
                        return "↑";
                    case TileOrientation.Down:
                        return "↓";
                    case TileOrientation.Left:
                        return "←";
                    default:
                        return "→";
                }
            }
        }

        public bool isExitTile { get; }
        public bool isMirrorTile { get; }

        public Tile(string sprite, ConsoleColor tileColor, bool isMirrorTile = false) : this()
        {
            this.sprite = sprite;
            TileColor = tileColor;
            Orientation = TileOrientation.None;
            isExitTile = false;
            this.isMirrorTile = isMirrorTile;
        }

        public Tile(ConsoleColor tileColor, TileOrientation orientation) : this()
        {
            sprite = ".";
            TileColor = tileColor;
            Orientation = orientation;
            isExitTile = true;
            isMirrorTile = false;
        }
    }
}
