using System.Collections.Generic;
using GameBaseArilox.API.Core;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.Implementation.zUpdaters
{
    public class MoveableGameElementUpdater : IUpdater 
    {
        private readonly List<IMoveableGameElement> _toUpdate = new List<IMoveableGameElement>();

        public MoveableGameElementUpdater()
        {

        }

        public MoveableGameElementUpdater(List<IMoveableGameElement> moveableGameElements )
        {
            _toUpdate = moveableGameElements;
        }

        public void Update(GameTime gameTime)
        {
            foreach (IMoveableGameElement moveableGameElement in _toUpdate)
            {
                moveableGameElement.Velocity += moveableGameElement.Acceleration;
                moveableGameElement.Position += moveableGameElement.Velocity;
            }
        }

        public void AddMoveableGameElement(IMoveableGameElement moveableGameElement)
        {
            _toUpdate.Add(moveableGameElement);
        }

        public void RemoveMoveableGameElement(IMoveableGameElement moveableGameElement)
        {
            _toUpdate.Remove(moveableGameElement);
        }
    }
}
