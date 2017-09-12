using System.Collections.Generic;
using GameBaseArilox.API.Shapes;
using GameBaseArilox.Implementation.Core;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.Implementation.Shapes
{
    public struct Segment : ISegment
    {
        private ICoordinates _point1;
        private ICoordinates _point2;
        private List<ICoordinates> _points;

        public ICoordinates Point1
        {
            get
            {
                return _point1;
            }
            set
            {
                if (value.X > _point2.X)
                {
                    _point1 = _point2;
                    _point2 = new Vector2D(value.X,value.Y);
                    Points = new List<ICoordinates>
                    {
                        _point1,_point2
                    };
                }
                else
                    _point1 = new Vector2D(value.X, value.Y);

            }
        }

        public ICoordinates Point2
        {
            get
            {
                return _point2;
            }
            set
            {
                if (value.X < _point1.X)
                {
                    _point2 = _point1;
                    _point1 = new Vector2D(value.X, value.Y);
                    Points = new List<ICoordinates>
                    {
                        _point1,_point2
                    };
                }
                else
                    _point2 = new Vector2D(value.X, value.Y);
            }
        }
        
        public float Slope
        {
            get
            {
                return (Point2.Y - Point1.Y) / (Point2.X - Point1.X);
            }
            set { }
        }

        public float YAt0
        {
            get { return Slope*Point1.X - Point1.Y; }
            set { }
        }

        public float Root => -YAt0 / Slope;


        public float Top => MathHelper.Min(Point1.Y, Point2.Y);
        public float Bot => MathHelper.Max(Point1.Y, Point2.Y);
        public float Right => MathHelper.Max(Point1.X, Point2.X);
        public float Left => MathHelper.Min(Point1.X, Point2.X);

        public List<ICoordinates> Points
        {
            get { return _points; }
            set
            {
                if (value.Count != 2) return;
                if (value[0].X > value[1].X)
                {
                    Point1 = value[1];
                    Point2 = value[0];
                    _points = new List<ICoordinates>
                    {
                        Point1,Point2
                    };
                }
                Point1 = value[0];
                Point2 = value[1];
                _points = new List<ICoordinates>
                {
                    Point1,Point2
                };
            }
        }

        public ICoordinates Center => new Vector2D((Point1.X+Point2.X)/2f,(Point1.Y+Point2.Y)/2f);

        public double Lenght => ShapesHelper.DistanceBetween(Point1,Point2);

        public Segment(Point point1, Point point2)
        {
            if (point1.X > point2.X)
            {

                _point1 = (Vector2D) point2;
                _point2 = (Vector2D) point1;
            }
            else
            {
                _point1 = (Vector2D)point1;
                _point2 = (Vector2D)point2;
            }
            _points = new List<ICoordinates>
            {
                _point1,_point2
            };
        }

        public Segment(Vector2 point1, Vector2 point2)
        {
            if (point1.X > point2.X)
            {

                _point1 = (Vector2D) point2;
                _point2 = (Vector2D) point1;
            }
            else
            {
                _point1 = (Vector2D)point1;
                _point2 = (Vector2D)point2;
            }
            _points = new List<ICoordinates>
            {
                _point1,_point2
            };
        }


        public Segment(ICoordinates point1, ICoordinates point2)
        {
            if (point1.X > point2.X)
            {

                _point1 = point2;
                _point2 = point1;
            }
            else
            {
                _point1 = point1;
                _point2 = point2;
            }
            _points = new List<ICoordinates>
            {
                _point1,_point2
            };
        }
    }
}
