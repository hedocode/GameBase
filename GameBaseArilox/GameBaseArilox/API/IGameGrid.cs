﻿using GameBaseArilox.API.Enums;

namespace GameBaseArilox.API
{
    public interface IGameGrid
    {
        GridType Type { get; set; }
        int XTiles { get; set; }
        int YTiles { get; set; }
    }
}
