using GameBaseArilox.API.Enums;

namespace GameBaseArilox.API.Environment
{
    public class TileMap : IGameGrid
    {
        public GridType Type { get; set; }
        public int XTiles { get; set; }
        public int YTiles { get; set; }
    }
}
