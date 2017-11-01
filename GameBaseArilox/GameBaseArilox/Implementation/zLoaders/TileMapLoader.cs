using System.IO;
using GameBaseArilox.API.Environment;
using Newtonsoft.Json;

namespace GameBaseArilox.Implementation.zLoaders
{
    public static class TileMapLoader
    {
        private const string Path = "Maps/";
        public static TileMap LoadTileMap(string mapName)
        {
            StreamReader sr = new StreamReader(Path + mapName);
            return null;
        }
    }
}
