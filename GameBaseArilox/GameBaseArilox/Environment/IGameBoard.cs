using GameBaseArilox.API.Environment;
using GameBaseArilox.API.Graphic;

namespace GameBaseArilox.Environment
{
    public interface IGameBoard
    {
        IGameGrid GameGrid { get; set; }
        IBackground Background { get; set; }
    }
}
