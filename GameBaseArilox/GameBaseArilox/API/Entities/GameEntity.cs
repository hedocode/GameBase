using System.Collections.Generic;
using GameBaseArilox.API.Detection;
using GameBaseArilox.API.Enums;
using GameBaseArilox.API.Graphic;
using GameBaseArilox.Implementation.Core;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.API.Entities
{
    public abstract class GameEntity : IGameEntity
    {
        private Vector2 _velocity;

        public string Name { get; set; }
        public Vector2 Position { get; set; }

        public float MaxVelocity { get; set; }

        public Vector2 Velocity {
            get { return _velocity; }
            set
            {
                if (value.Length() > MaxVelocity)
                {
                    Vector2D v = (Vector2D)value;
                    v.SetLenght(MaxVelocity);
                    _velocity = v;
                }
            }
        }

        public Vector2 Acceleration { get; set; }
        public int MaxHealthPoints { get; set; }
        public int HealthPoints { get; set; }
        public bool IsInvincible { get; set; }

        public abstract void OnDeath();
        public abstract void OnHit();

        public ISprite Sprite { get; set; }
        public IDetectionArea Hitbox { get; set; }

        public abstract void OnClick();
        public abstract void OnHover();
        public abstract void OnPressed();
        public abstract void OnRelease();

        public int Level { get; set; }
        public Dictionary<Stat, float> Stats { get; set; }
        public Dictionary<Stat, float> StatsPerLevel { get; set; }
        public abstract void OnSpawn();
    }
}
