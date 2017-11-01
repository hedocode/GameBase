using System;
using System.Collections.Generic;
using GameBaseArilox.API.Core;
using GameBaseArilox.API.Effects;
using GameBaseArilox.API.Entities;
using GameBaseArilox.API.Enums;
using GameBaseArilox.API.Graphic;
using GameBaseArilox.Implementation.Shapes;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.Implementation.Graphic
{
    public class ParticleGenerator : IRotatable, IGenerator
    {
        private float _x;
        private float _y;
        private float _rotationDegrees;
        private float _sprayAngle;
        private Dictionary<string, int> _spritePercentage;
        public float ParticlesPerGeneration { get; set; }
        private Random _randomMachine = new Random();

        public ParticleGenerator(Dictionary<string, int> spritePercentage, float rotation, float sprayAngle, float duration, float frequency, float particlesPerGeneration)
        {
            _x = 0;
            _y = 0;
            _spritePercentage = spritePercentage;
            Rotation = rotation;
            SprayAngle = sprayAngle;
            Duration = duration;
            Frequency = frequency;
            ParticlesPerGeneration = particlesPerGeneration;
        }

        public ParticleGenerator(float x, float y, Dictionary<string, int> spritePercentage, float rotation, float sprayAngle, float duration, float frequency, float particlesPerGeneration)
        {
            _x = x;
            _y = y;
            _spritePercentage = spritePercentage;
            Rotation = rotation;
            SprayAngle = sprayAngle;
            Duration = duration;
            Frequency = frequency;
            ParticlesPerGeneration = particlesPerGeneration;
        }

        public ParticleGenerator(float x, float y, Dictionary<string, int> spritePercentage, Direction direction, float sprayAngle, float duration, float frequency, float particlesPerGeneration)
        {
            _x = x;
            _y = y;
            _spritePercentage = spritePercentage;
            Rotation = AngleHelper.DirectionToFloat(direction);
            SprayAngle = sprayAngle;
            Duration = duration;
            Frequency = frequency;
            ParticlesPerGeneration = particlesPerGeneration;
        }

        public ParticleGenerator(float x, float y, Dictionary<string, int> spritePercentage, Direction direction, Angle sprayAngle, float duration, float frequency, float particlesPerGeneration)
        {
            _x = x;
            _y = y;
            _spritePercentage = spritePercentage;
            Rotation = AngleHelper.DirectionToFloat(direction);
            SprayAngle = sprayAngle;
            Duration = duration;
            Frequency = frequency;
            ParticlesPerGeneration = particlesPerGeneration;
        }

        public ParticleGenerator(Vector2 position, Dictionary<string, int> spritePercentage, Direction direction, Angle sprayAngle, float duration, float frequency, float particlesPerGeneration)
        {
            _x = position.X;
            _y = position.Y;
            _spritePercentage = spritePercentage;
            Rotation = AngleHelper.DirectionToFloat(direction);
            SprayAngle = sprayAngle;
            Duration = duration;
            Frequency = frequency;
            ParticlesPerGeneration = particlesPerGeneration;
        }

        public Vector2 Position
        {
            get
            {
                return new Vector2(_x, _y);
            }
            set
            {
                _x = value.X;
                _y = value.Y;
            }
        }

        public float Rotation
        {
            get { return _rotationDegrees; }
            set { _rotationDegrees = new Angle(value); }
        }

        public float SprayAngle
        {
            get { return _sprayAngle; }
            set { _sprayAngle = new Angle(value); }
        }

        public double TimeSpent { get; set; }
        public bool Increase { get; set; }
        public float Duration { get; set; }
        public float Frequency { get; set; }
        public double ElapsedLifeTime { get; set; }

        public void Generate(GameModel game)
        {
            int lowerBound=0;
            int upperBound=0;
            foreach (string textureId in _spritePercentage.Keys)
            {
                int texturePercentage;
                _spritePercentage.TryGetValue(textureId, out texturePercentage);
                lowerBound = upperBound;
                upperBound += texturePercentage;
                for (int i = 0; i < ParticlesPerGeneration; i++)
                {
                    int angle = _randomMachine.Next(0, (int)_sprayAngle);

                    int result = _randomMachine.Next(1,100);
                    if (result >= lowerBound && result < upperBound)
                    {
                        float duration = 10;
                        ISprite sprite = new Particle(_x, _y, 32, 32, textureId, duration+1);
                        new MultipleDrawableEffects(new List<IDrawableEffectOverTime>
                        {
                            //new DrawableFlashingEffectOverTime(2,6f),
                            new DrawableRotateFadeMovingEffect(0.1f, duration, 20, new Angle(-Rotation+(angle-_sprayAngle/2)))
                        }, sprite, 5);
                        game.AddDrawable(sprite);
                    }
                }
            }
        }
    }
}
