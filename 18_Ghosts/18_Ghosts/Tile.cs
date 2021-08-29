using System;
using System.Collections.Generic;
using System.Text;

namespace _18_Ghosts
{
    /// <summary>
    /// Struct Tile contem toda a informação sobre os tiles de jogo
    /// </summary>
    struct Tile
    {
        // Cor do tile
        public ConsoleColor TileColor { get; }
        
        // Orientação do Tile
        private TileOrientation orientation;
        public TileOrientation Orientation {
            get => orientation;
            set => orientation = (int)value == 5 ? TileOrientation.Up : value;
        }

        // Fantasma presente no Tile
        public Ghost TileGhost { get; set; }

        // Sprite default do Tile
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

        // Se é um tile de saida
        public bool isExitTile { get; }
        // Se é um tile espelho
        public bool isMirrorTile { get; }

        /// <summary>
        /// Construtor Tile para Tiles normais ou de espelho
        /// </summary>
        /// <param name="sprite">A sprite do Tile</param>
        /// <param name="tileColor">A cor do Tile</param>
        /// <param name="isMirrorTile">Se o tile é espelho</param>
        public Tile(string sprite, ConsoleColor tileColor, bool isMirrorTile = false) : this()
        {
            this.sprite = sprite;
            TileColor = tileColor;
            Orientation = TileOrientation.None;
            isExitTile = false;
            this.isMirrorTile = isMirrorTile;
        }

        /// <summary>
        /// Construtor Tile para Tiles de Saida
        /// </summary>
        /// <param name="tileColor">A cor do Tile</param>
        /// <param name="orientation">A orientação do Tile</param>
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
