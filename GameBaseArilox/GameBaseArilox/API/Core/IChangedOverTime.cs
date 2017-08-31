namespace GameBaseArilox.API.Core
{
    public interface IChangedOverTime
    {
        double TimeSpent { get; set; }
        bool Increase { get; set; }
    }
}
