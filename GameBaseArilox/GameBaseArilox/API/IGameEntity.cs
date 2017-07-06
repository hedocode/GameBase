using System.Collections.Generic;
using GameBaseArilox.API.Enums;

namespace GameBaseArilox.API
{
    public interface IGameEntity : INamed, IMoveableGameElement, IKillable, IDisplayed
    {
        int Level { get; set; }
        Dictionary<Stat,float> Stats { get; set; }
        Dictionary<Stat,float> StatsPerLevel { get; set; }
        void OnSpawn();
    }
}
