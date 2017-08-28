using GameBaseArilox.API.Environment;

namespace GameBaseArilox.API.Shapes
{
    public interface IRectangle : IGameElement, IShapeCollider, IShape
    {
        float Height { get; set; }
        float Width { get; set; }
    }
}
