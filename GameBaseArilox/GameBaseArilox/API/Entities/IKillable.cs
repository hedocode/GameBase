namespace GameBaseArilox.API.Entities
{
    public interface IKillable
    {
        int MaxHealthPoints { get; set; }
        int HealthPoints { get; set; }
        bool IsInvincible { get; set; }
        void OnDeath();
        void OnHit();
    }
}
