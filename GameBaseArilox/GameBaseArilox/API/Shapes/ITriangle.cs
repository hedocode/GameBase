using Microsoft.Xna.Framework;

namespace GameBaseArilox.API.Shapes
{
    public interface ITriangle : IShape
    {
        Vector2 Point1 { get; set; }
        Vector2 Point2 { get; set; }
        Vector2 Point3 { get; set; }
    }
}
