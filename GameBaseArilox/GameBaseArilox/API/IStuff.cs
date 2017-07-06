﻿using System.Collections.Generic;
using GameBaseArilox.API.Enums;

namespace GameBaseArilox.API
{
    public interface IStuff : IItem
    {
        StuffSlot Slot { get; set; }
        int RequiredLevel { get; set; }
        Dictionary<Stat, float> Stats { get; set; }
    }
}
