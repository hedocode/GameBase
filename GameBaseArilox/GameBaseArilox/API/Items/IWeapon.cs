using GameBaseArilox.API.Enums;

namespace GameBaseArilox.API.Items
{
    interface IWeapon : IStuff
    {
        DamageType WeaponDamageType { get; set; }
        int MaxAmmunition { get; set; }
        int Ammunition { get; set; }
        float AttackSpeed { get; set; }
        float Damages { get; set; }
        float Range { get; set; }
        float ReloadTime { get; set; }
    }
}
