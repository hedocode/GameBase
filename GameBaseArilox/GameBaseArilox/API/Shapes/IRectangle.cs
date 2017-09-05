using GameBaseArilox.API.Core;
using GameBaseArilox.API.Environment;

namespace GameBaseArilox.API.Shapes
{
    public interface IRectangle : IGameElement, IShape, IRotatable
    {
        float Height { get; set; }
        float Width { get; set; }
    }
}
