using GameBaseArilox.API.Enums;

namespace GameBaseArilox.API
{
    interface IProjectile : IGameEntity
    {
        DamageType DamageType { get; set; }
        int Damages { get; set; }
    }
}
