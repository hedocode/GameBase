using System.Collections.Generic;
using GameBaseArilox.API.Core;
using GameBaseArilox.API.Enums;
using GameBaseArilox.API.Graphic;

namespace GameBaseArilox.API.Entities
{
    public interface IGameEntity : INamed, IMoveableGameElement, IKillable, IDisplayed
    {
        int Level { get; set; }
        Dictionary<Stat,float> Stats { get; set; }
        Dictionary<Stat,float> StatsPerLevel { get; set; }
        void OnSpawn();
    }
}
