using GameBaseArilox.API.Effects;
using GameBaseArilox.API.Environment;

namespace GameBaseArilox.API.Entities
{
    public interface IGenerator : IGameElement, IChangedOverTime, IEffectOverTime
    {
        void Generate(GameModel game);
    }
}