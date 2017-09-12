using GameBaseArilox.API.Shapes;
using GameBaseArilox.Implementation.Shapes;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.UnitTest
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class TestShapes : GameModel
    {
        private readonly ISegment _s1;
        private readonly ISegment _s2;
        private readonly ISegment _s3;
        private readonly ISegment _s4;
        private ICoordinates _point1;
        private ICoordinates _intersectionPoint1;
        private ICoordinates _intersectionPoint2;
        private IShape _triangle;
        private int _count;

        public TestShapes()
        {
            _s1 = new Segment(new Vector2(50.6f, 49.5f), new Vector2(460.5f, 48.592f));
            _s2 = new Segment(new Vector2(100, 400), new Vector2(300, 30));

            _s3 = new Segment(new Vector2(150,160), new Vector2(20, 250));
            _s4 = new Segment(new Vector2(140, 130), new Vector2(10,300) );
            
            _point1 = new Point2D(450,400);
            _intersectionPoint1 = new Point2D();
            _intersectionPoint2 = new Point2D();
            _triangle = new Triangle(_s1.Point2,_s2.Point1,_point1);

            ShapeDrawer.AddShape(_s1);
            ShapeDrawer.AddShape(_s2);
            ShapeDrawer.AddShape(_s3);
            ShapeDrawer.AddShape(_s4);
            ShapeDrawer.AddShape(_triangle);
            ShapeDrawer.AddPoint(_intersectionPoint1);
            ShapeDrawer.AddPoint(_intersectionPoint2);
        }


        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (ShapesHelper.Intersects(_s1, _s2))
            {
                ShapesHelper.IntersectionPointBetween(_s1, _s2, _intersectionPoint1);
            }

            if (ShapesHelper.Intersects(_s3, _s4))
            {
                ICoordinates c2 = ShapesHelper.IntersectionPointBetween(_s3, _s4);
                _intersectionPoint2.X = c2.X;
                _intersectionPoint2.Y = c2.Y;
            }

            if (_count <= 301)
            {
                _s1.Point2.Y ++;
                _s2.Point1.X ++;
                _s3.Point2.Y ++;
                _s4.Point2.Y ++;
                _count ++;
            }

            base.Update(gameTime);
        }
    }
}
