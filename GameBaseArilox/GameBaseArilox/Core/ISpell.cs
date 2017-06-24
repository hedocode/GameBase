using System.Collections.Generic;
using GameBaseArilox.Core.Enums;

namespace GameBaseArilox.Core
{
    public interface ISpell : INamed
    {
        float Cooldown { get; set; }
        int Damages { get; set; }
        int Range { get; set; }
        int Cost { get; set; }
        Dictionary<Ressource,int> RessourcesUsed { get; set; }
    }
}
