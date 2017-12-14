using GameBaseArilox.API.Core;
using GameBaseArilox.Implementation.zUpdaters;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.Implementation.Commands
{
    public class MoveCameraTop : ICommand
    {
        private readonly CameraUpdater _cameraUpdater;

        public MoveCameraTop(CameraUpdater cameraUpdater)
        {
            _cameraUpdater = cameraUpdater;
        }
        public void Execute(GameTime gameTime)
        {
            _cameraUpdater.RequestTop();
        }
    }
}
