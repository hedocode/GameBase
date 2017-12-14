using GameBaseArilox.API.Core;
using GameBaseArilox.Implementation.zUpdaters;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.Implementation.Commands
{
    public class MoveCameraBot : ICommand
    {
        private readonly CameraUpdater _cameraUpdater;

        public MoveCameraBot(CameraUpdater cameraUpdater)
        {
            _cameraUpdater = cameraUpdater;
        }
        public void Execute(GameTime gameTime)
        {
            _cameraUpdater.RequestBot();
        }
    }
}
