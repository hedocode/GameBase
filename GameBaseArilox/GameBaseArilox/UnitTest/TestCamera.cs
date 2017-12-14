using GameBaseArilox.API.Enums;
using GameBaseArilox.Implementation.Core;
using GameBaseArilox.Implementation.Entities;

namespace GameBaseArilox.UnitTest
{
    public class TestCamera : GameModel
    {
        public TestCamera()
        {
            Moumoune m = new Moumoune(100, 100);
            AddEntity(m);
            CameraUpdater.AddCamera(new Camera2D(Viewport, null, CameraType.Fixed));
        }
    }
}
