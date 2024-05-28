namespace Fight_or_Die.Files.Configs;

public class ConsoleConfig
{
    public ConsoleConfig()
    {
        Width = 106;
        Height = 30;
        OutLineThick = 1;
        Displacement = 1;
        MinUserX = OutLineThick;
        MinUserY = OutLineThick;
        MaxUserX = Width - OutLineThick - Displacement;
        MaxUserY = Height - OutLineThick - Displacement;
    }

    public readonly int Width;
    public readonly int Height;
    public readonly int OutLineThick;
    public readonly int Displacement;
    public readonly int MinUserX;
    public readonly int MinUserY;
    public readonly int MaxUserX;
    public readonly int MaxUserY;
}