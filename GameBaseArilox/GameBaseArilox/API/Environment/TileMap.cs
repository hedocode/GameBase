using GameBaseArilox.API.Enums;

namespace GameBaseArilox.API.Environment
{
    public class TileMap : IGameGrid
    {
        public GridType Type { get; set; }
        public ITile[,] Map { get; set; }
        public int XTiles { get; set; }
        public int YTiles { get; set; }
        
        public int Tilewidth { get; set; }

        public TileMap(int width, int height )
        {
            XTiles = width;
            YTiles = height;
            Map = new ITile[width,height];
        }
    }
}
