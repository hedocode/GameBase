using GameBaseArilox.API.Enums;

namespace GameBaseArilox.API.Entities
{
    interface IProjectile : IGameEntity
    {
        DamageType DamageType { get; set; }
        int Damages { get; set; }
    }
}
