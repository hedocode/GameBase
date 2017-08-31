namespace GameBaseArilox.API.Shapes
{
    public struct Vector2D : IVector2D
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector2D(float x, float y)
        {
            X = x;
            Y = y;
        }


    }
}
