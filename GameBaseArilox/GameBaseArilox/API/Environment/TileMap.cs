using GameBaseArilox.API.Enums;

namespace GameBaseArilox.API.Environment
{
    public class TileMap : IGameGrid
    {
        public GridType Type { get; set; }
        public ITile[,] Map { get; set; }
        public int XTiles { get; set; }
        public int YTiles { get; set; }

        public string orientation { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public int tilewidth { get; set; }
        public string renderorder { get; set; }
        public int version { get; set; }
        public int nextobjectid { get; set; }
        public int layers { get; set; }
        public int tilesets { get; set; }

        public TileMap(int width, int height )
        {
            
        }
    }
}
