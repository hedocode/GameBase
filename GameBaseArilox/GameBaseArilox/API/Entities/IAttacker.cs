namespace GameBaseArilox.API.Entities
{
    public interface IAttacker
    {
        float AttackDamage { get; set; }
        float AttackSpeed { get; set; }
        float CriticalChance { get; set; }
        float AttackRange { get; set; }
        float Accuracy { get; set; }
    }
}
