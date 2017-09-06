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
        private ISegment _s1;
        private ISegment _s2;
        private Point2D _point1;
        private IShape _triangle;
        private int _count;

        public TestShapes()
        {
            _s1 = new Segment(new Vector2(100, 400), new Vector2(300, 30));
            _s2 = new Segment(new Vector2(50.6f, 49.5f), new Vector2(460.5f,48.592f));
            _point1 = new Point2D(450,400);
            _triangle = new Triangle(_s1.Point1,_s2.Point2,_point1);

            ShapeDrawer.AddShape(_s1);
            ShapeDrawer.AddShape(_s2);
            ShapeDrawer.AddShape(_triangle);
            //ShapeDrawer.AddShape(_point1);
        }


        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            _point1 = new Point2D(ShapesHelper.IntersectionPointBetween(_s1, _s2));
            if (_count <= 300)
            {
                _s1.Point1.X++;
                _s2.Point2.Y++;
                _count ++;
            }

            base.Update(gameTime);
        }
    }
}
