using System.Collections.Generic;
using GameBaseArilox.API.Core;
using GameBaseArilox.Implementation.Controls;
using GameBaseArilox.Implementation.Graphic;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.Implementation.Commands
{
    public class GenerateDustOnClick : ICommand
    {
        private ParticleGenerator _particleGenerator;
        private readonly GameModel _gameModel;
        private readonly MouseInputs _mouse;
        public GenerateDustOnClick(GameModel gameModel, MouseInputs mouse)
        {
            Dictionary<string, int> particlesDico = new Dictionary<string, int>
            {
                {"dustParticle", 100}
            };
            _particleGenerator = new ParticleGenerator(particlesDico,0,360,0,1, 80);
            _gameModel = gameModel;
            _mouse = mouse;
        }

        public void Execute(GameTime gameTime)
        {
            _particleGenerator.Position = _mouse.GetMouseMapPosition(_gameModel.CurrentCamera);
            _particleGenerator.Generate(_gameModel);
        }
    }
}
