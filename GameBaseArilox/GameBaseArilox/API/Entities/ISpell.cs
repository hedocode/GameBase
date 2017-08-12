using System.Collections.Generic;
using GameBaseArilox.API.Core;
using GameBaseArilox.API.Enums;

namespace GameBaseArilox.API.Entities
{
    public interface ISpell : INamed
    {
        float Cooldown { get; set; }
        int Damages { get; set; }
        int Range { get; set; }
        int Cost { get; set; }
        Dictionary<Ressource,int> RessourcesUsed { get; set; }
        void Cast();
    }
}
