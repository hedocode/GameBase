namespace GameBaseArilox.API.Shapes
{
    struct Ray2D : ILine
    {
        public float XStart { get; set; }
        public bool TowardsPositive { get; set; }
        //ANGLE
        public float Slope { get; set; }
        public float YAt0 { get; set; }
    }
}
