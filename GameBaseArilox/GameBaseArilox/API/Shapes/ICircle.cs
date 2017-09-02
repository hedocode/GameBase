using GameBaseArilox.API.Environment;

namespace GameBaseArilox.API.Shapes
{
    public interface ICircle : IGameElement, IShape
    {
        float Radius { get; set; }
        float Diameter { get; set; }
        float Circumference { get; set; }
        double Area { get; set; }
    }
}
