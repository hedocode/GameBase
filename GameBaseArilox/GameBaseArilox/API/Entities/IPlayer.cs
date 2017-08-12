using System.Collections.Generic;
using GameBaseArilox.API.Enums;
using GameBaseArilox.API.Items;

namespace GameBaseArilox.API.Entities
{
    interface IPlayer : IGameEntity, IAttacker, ISpellCaster
    {
        Dictionary<StuffSlot, IStuff> Stuff { get; set; }
    }
}
