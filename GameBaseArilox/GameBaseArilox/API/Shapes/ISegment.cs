﻿using Microsoft.Xna.Framework;

namespace GameBaseArilox.API.Shapes
{
    public interface ISegment : IShapeCollider, ILine, IShape
    {
        Point Point1 { get; set; }
        Point Point2 { get; set; }

        double Lenght { get; }
    }
}
