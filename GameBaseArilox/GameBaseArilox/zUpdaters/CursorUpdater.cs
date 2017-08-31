using GameBaseArilox.API.Core;
using GameBaseArilox.Controls;
using GameBaseArilox.GUI;
using Microsoft.Xna.Framework;
namespace GameBaseArilox.zUpdaters
{
    public class CursorUpdater : IUpdater
    {
        private readonly Cursor _cursorToUpdate;
        private readonly MouseInputs _mouseInputs;

        public CursorUpdater(GameModel game, Cursor cursor, MouseInputs mouseInputs)
        {
            _cursorToUpdate = cursor;
            _mouseInputs = mouseInputs;
            game.AddToUpdaters(this);
        }

        public void Update(GameTime gameTime)
        {
            _cursorToUpdate.ScreenPosition = _mouseInputs.GetMouseAbsolutePosition();
        }
    }
}
