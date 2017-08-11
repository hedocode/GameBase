using Microsoft.Xna.Framework;

namespace GameBaseArilox.API
{
    public interface IEffect
    {
        float Duration { get; set; }
        float TimeSpent { get; set; }
        void Affect(GameTime gameTime);
    }
}
