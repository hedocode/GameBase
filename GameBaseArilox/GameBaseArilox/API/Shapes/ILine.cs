namespace GameBaseArilox.API.Shapes
{
    public interface ILine
    {
        float Slope { get; set; }
        float YAt0 { get; set; }
        float Root { get; }
    }
}
