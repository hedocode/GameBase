using GameBaseArilox.API.Core;
using GameBaseArilox.Implementation.Controls;
using GameBaseArilox.Implementation.GUI;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.Implementation.zUpdaters
{
    public class CursorUpdater : IUpdater
    {
        private readonly Cursor _cursorToUpdate;
        private readonly MouseInputs _mouseInputs;
        private CameraUpdater _cameraUpdater;

        public CursorUpdater(GameModel game, Cursor cursor, MouseInputs mouseInputs)
        {
            _cursorToUpdate = cursor;
            _mouseInputs = mouseInputs;
            _cameraUpdater = game.CameraUpdater;
            game.AddToUpdaters(this);
        }

        public void Update(GameTime gameTime)
        {
            _cursorToUpdate.ScreenPosition = _mouseInputs.GetMouseAbsolutePosition();
        }
    }
}
