using System.Collections.Generic;
using GameBaseArilox.Implementation.Graphic;

namespace GameBaseArilox.UnitTest
{
    public class TestParticleGenerator : GameModel
    {
        private ParticleGenerator _particleGenerator;
        public TestParticleGenerator()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>
            {
                {"dustParticle", 100}
            };
            _particleGenerator = new ParticleGenerator(250,250, dictionary, -90, 90, 10, 1, 1);
            GeneratorUpdater.AddGenerator(_particleGenerator);
        }
    }
}
