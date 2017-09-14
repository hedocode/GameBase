using System;
using System.Collections.Generic;
using GameBaseArilox.API.Core;
using GameBaseArilox.API.Entities;
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
        private float _particlesPerGeneration;
        private Random randomMachine = new Random();

        public ParticleGenerator(float x, float y, Dictionary<string, int> spritePercentage, float rotation, float sprayAngle, float duration, float speed, float particlesPerGeneration)
        {
            _x = x;
            _y = y;
            _spritePercentage = spritePercentage;
            _rotationDegrees = rotation;
            _sprayAngle = sprayAngle;
            Duration = duration;
            Speed = speed;
            _particlesPerGeneration = particlesPerGeneration;
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
                _y = value.X;
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
        public float Speed { get; set; }

        public float LifeTime { get; set; }
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
                for (int i = 0; i < _particlesPerGeneration; i++)
                {
                    int result = randomMachine.Next(1,100);
                    if (result >= lowerBound && result < upperBound)
                    {
                        ISprite sprite = new Sprite(_x, _y, 32, 32, textureId);
                        game.AddDrawable(sprite);
                    }
                }
                
            }
        }
    }
}
