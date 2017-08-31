using Microsoft.Xna.Framework;

namespace GameBaseArilox.API.Core
{
    public interface IEffectObject
    {
        void Affect(GameTime gameTime);
        object AffectedObject { get; set; }
        object BaseObject { get; }
        void Reset();
    }
}
