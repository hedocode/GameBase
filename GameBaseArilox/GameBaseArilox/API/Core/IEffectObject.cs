using Microsoft.Xna.Framework;

namespace GameBaseArilox.API.Core
{
    public interface IEffectObject
    {
        void Affect(GameTime gameTime);
        object AffectedObject { get; set; }
        void Reset();
    }
}
