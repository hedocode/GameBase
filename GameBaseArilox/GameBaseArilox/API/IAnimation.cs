using Microsoft.Xna.Framework;

namespace GameBaseArilox.API
{
    public interface IAnimation
    {
        float Duration { get; set; }
        float TimeSpent { get; set; }
        void Animate(GameTime gameTime);
    }
}
