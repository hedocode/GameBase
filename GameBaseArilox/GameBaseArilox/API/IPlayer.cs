using System.Collections.Generic;
using GameBaseArilox.API.Enums;

namespace GameBaseArilox.API
{
    interface IPlayer : IGameEntity, IAttacker, ISpellCaster
    {
        Dictionary<StuffSlot, IStuff> Stuff { get; set; }
    }
}
