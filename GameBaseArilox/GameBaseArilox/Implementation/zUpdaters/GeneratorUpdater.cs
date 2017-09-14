using System.Collections.Generic;
using GameBaseArilox.API.Core;
using GameBaseArilox.API.Entities;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.Implementation.zUpdaters
{
    public class GeneratorUpdater : IUpdater
    {
        private List<IGenerator> _toUpdate;
        private GameModel _game;

        public GeneratorUpdater(GameModel game)
        {
            _game = game;
        }

        public void Update(GameTime gameTime)
        {
            foreach (IGenerator generator in _toUpdate)
            { 
                generator.Generate(_game);
                generator.TimeSpent += gameTime.ElapsedGameTime.TotalSeconds;
                if (generator.Duration >= generator.TimeSpent) _toUpdate.Remove(generator);
            }
        }
    }
}
