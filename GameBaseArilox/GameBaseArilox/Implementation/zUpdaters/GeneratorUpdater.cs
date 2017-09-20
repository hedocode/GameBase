using System.Collections.Generic;
using GameBaseArilox.API.Core;
using GameBaseArilox.API.Entities;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.Implementation.zUpdaters
{
    public class GeneratorUpdater : IUpdater
    {
        private List<IGenerator> _toRemove;
        private readonly List<IGenerator> _toUpdate;
        private readonly GameModel _game;

        public GeneratorUpdater(GameModel game)
        {
            _game = game;
            _toRemove = new List<IGenerator>();
            _toUpdate = new List<IGenerator>();
            game.AddToUpdaters(this);
        }

        public void Update(GameTime gameTime)
        {
            foreach (IGenerator generator in _toRemove)
            {
                _toUpdate.Remove(generator);
            }
            foreach (IGenerator generator in _toUpdate)
            {
                if (generator.TimeSpent >= generator.Frequency)
                {
                    generator.Generate(_game);
                    generator.TimeSpent = 0;
                }
                generator.ElapsedLifeTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                generator.TimeSpent += (float) gameTime.ElapsedGameTime.TotalSeconds;
                if (generator.ElapsedLifeTime >= generator.Duration) _toRemove.Add(generator);
            }
        }

        public void AddGenerator(IGenerator generator)
        {
            _toUpdate.Add(generator);
        }
    }
}
