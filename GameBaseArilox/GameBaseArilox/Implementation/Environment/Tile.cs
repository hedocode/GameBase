using GameBaseArilox.API.Environment;

namespace GameBaseArilox.Implementation.Environment
{
    public class Tile : ITile
    {
        public int Id { get; set; }
        public bool Solid { get; set; }
    }
}
