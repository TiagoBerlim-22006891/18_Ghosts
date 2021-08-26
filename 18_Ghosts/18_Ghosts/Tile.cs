using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Ghosts
{
    struct Tile
    {
        public ConsoleColor TileColor { get; }
        public TileOrientation Orientation { get; set; }

        public Ghost Tghost { get; set; }

        public bool isExitTile { get; }
        public bool isMirrorTile { get; }

        public Tile(ConsoleColor TileColor, bool isMirrorTile = false) : this()
        {
            this.TileColor = TileColor;
            Orientation = TileOrientation.None;
            isExitTile = false;
            this.isMirrorTile = isMirrorTile;
        }

        public Tile(ConsoleColor TileColor, TileOrientation Orientation) : this()
        {
            this.TileColor = TileColor;
            this.Orientation = Orientation;
            isExitTile = true;
            isMirrorTile = false;
        }
    }
}
