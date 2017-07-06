using GameBaseArilox.API;
using GameBaseArilox.API.Enums;

namespace GameBaseArilox.Environment
{
    class TileMapGrid : IGameGrid
    {
        private GridType _mapType;
        private readonly Tile[,] _map;

        public GridType Type
        {
            get { return _mapType; }
            set { _mapType = value; }
        }

        public int XTiles { get; set; }
        public int YTiles { get; set; }

        public TileMapGrid()
        {
            _map = new Tile[XTiles,YTiles];
        }

        public Tile GetTile(int x, int y)
        {
            if (x <= XTiles && y <= YTiles)
            {
                return _map[x, y];
            }
            return new Tile();
        }
    }
}
