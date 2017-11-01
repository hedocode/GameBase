using System.Collections.Generic;
using GameBaseArilox.API.Core;
using GameBaseArilox.API.Enums;

namespace GameBaseArilox.API.Entities
{
    public interface IGameEntity : INamed, IMoveableGameElement, IKillable, IClickable
    {
        int Level { get; set; }
        Dictionary<Stat,float> Stats { get; set; }
        Dictionary<Stat,float> StatsPerLevel { get; set; }
        void OnSpawn();
    }
}
