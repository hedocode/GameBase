using System.Collections.Generic;
using GameBaseArilox.Core.Enums;

namespace GameBaseArilox.Core
{
    public interface ISpellCaster
    {
        Dictionary<Ressource, float> MaxRessources { get; set; }
        Dictionary<Ressource, float> MinRessources { get; set; }
        Dictionary<Ressource,float> Ressources { get; set; }
        Dictionary<Ressource,float> Regeneration { get; set; }
        List<ISpell> Spells { get; set; }
    }
}
