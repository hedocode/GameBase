using System.Collections.Generic;
using GameBaseArilox.API.Graphic;
using GameBaseArilox.Implementation.GUI;

namespace GameBaseArilox.API.Core
{
    public interface IGame
    {
        List<IDrawer> Drawers { get; set; }
        List<IUpdater> Updaters { get; set; }
        List<IContentLoader> Loaders { get; set; }
        Cursor Cursor { get; set; }
    }
}
