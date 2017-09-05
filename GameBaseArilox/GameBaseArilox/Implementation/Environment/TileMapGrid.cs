using GameBaseArilox.API.Enums;
using GameBaseArilox.API.Environment;

namespace GameBaseArilox.Implementation.Environment
{
    public class TileMapGrid : IGameGrid
    {
        public GridType Type { get; set; }

        public ITile[,] Map { get; set; }

        public int XTiles { get; set; }
        public int YTiles { get; set; }

        public TileMapGrid()
        {
            Map = new ITile[XTiles,YTiles];
        }

        public ITile GetTile(int x, int y)
        {
            if (x <= XTiles && y <= YTiles)
            {
                return Map[x, y];
            }
            return new Tile();
        }
    }
}
