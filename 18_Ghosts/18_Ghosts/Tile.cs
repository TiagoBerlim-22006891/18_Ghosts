using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Ghosts
{
    struct Tile
    {
        public TileColor Color { get; }
        public TileOrientation Orientation { get; set; }

        public Ghost Tghost { get; set; }

        public bool isExitTile { get; }
        public bool isMirrorTile { get; }

        public Tile(TileColor Color, bool isMirrorTile = false) : this()
        {
            this.Color = Color;
            Orientation = TileOrientation.None;
            isExitTile = false;
            this.isMirrorTile = isMirrorTile;
        }

        public Tile(TileColor Color, TileOrientation Orientation) : this()
        {
            this.Color = Color;
            this.Orientation = Orientation;
            isExitTile = true;
            isMirrorTile = false;
        }
    }
}
