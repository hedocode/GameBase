using GameBaseArilox.API.Core;
using GameBaseArilox.Implementation.zUpdaters;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.Implementation.Commands
{
    public class MoveCameraLeft : ICommand
    {
        private readonly CameraUpdater _cameraUpdater;

        public MoveCameraLeft(CameraUpdater cameraUpdater)
        {
            _cameraUpdater = cameraUpdater;
        }
        public void Execute(GameTime gameTime)
        {
            _cameraUpdater.RequestLeft();
        }
    }
}
