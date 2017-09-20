using Microsoft.Xna.Framework;

namespace GameBaseArilox.Implementation.Graphic
{
    public class Particle : Sprite
    {
        public Particle(string textureId, float duration) : base(textureId)
        {
            Duration = duration;
        }

        public Particle(float x, float y, string textureId, float duration) : base(x, y, textureId)
        {
            Duration = duration;
        }

        public Particle(float x, float y, int width, int height, string textureId, float duration) : base(x, y, width, height, textureId)
        {
            Duration = duration;
        }

        public Particle(float x, float y, int width, int height, string textureId, Vector2 origin, float duration) : base(x, y, width, height, textureId, origin)
        {
            Duration = duration;
        }

        public Particle(float x, float y, int width, int height, string textureId, Vector2 origin, string currentAnimation, float duration) : base(x, y, width, height, textureId, origin, currentAnimation)
        {
            Duration = duration;
        }

        public Particle(float x, float y, int width, int height, string textureId, Vector2 origin, string currentAnimation, float depth, float duration) : base(x, y, width, height, textureId, origin, currentAnimation, depth)
        {
            Duration = duration;
        }
    }
}
