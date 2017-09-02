namespace GameBaseArilox.API.Shapes
{
    public interface ISegment : ILine, IShape
    {
        ICoordinates Point1 { get; set; }
        ICoordinates Point2 { get; set; }

        double Lenght { get; }
    }
}
