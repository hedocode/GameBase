namespace GameBaseArilox.API.Shapes
{
    static class ShapeCollissionDetector
    {
        public static bool Intersects(IRectangle r1, IRectangle r2)
        {
            return r1.Top <= r2.Bot || r1.Right >= r2.Left;
        }

        public static bool Intersects(ICircle c1, ICircle c2)
        {
            return new Segment(c1.Position,c2.Position).Lenght <= c1.Radius + c2.Radius;
        }

    }
}
