using GameBaseArilox.API.Shapes;

namespace GameBaseArilox.Implementation.Shapes
{
    struct Line : ILine
    {
        public float Root => -YAt0/Slope;

        public float Slope { get; set; }
        public float YAt0 { get; set; }

        public Angle AngleFromXAxis
        {
            get { return AngleHelper.SlopeToAngle(Slope); }
            set
            {
                Slope = AngleHelper.AngleToSlope(value);
            }
        }

        public Line(int slope, int yAt0)
        {
            Slope = slope;
            YAt0 = yAt0;
        }

        public Line(ICoordinates point, Angle angle)
        {
            Slope = AngleHelper.AngleToSlope(angle);
            YAt0 = point.Y - point.X*Slope;
        }
    }
}
