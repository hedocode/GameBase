namespace GameBaseArilox.API.Shapes
{
    public interface ITriangle : IShape
    {
        ICoordinates Point1 { get; set; }
        ICoordinates Point2 { get; set; }
        ICoordinates Point3 { get; set; }
    }
}
