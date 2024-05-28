using System.Runtime.CompilerServices;

namespace Fight_or_Die.Configs;

public class ConsoleConfig
{
    public ConsoleConfig()
    {
        Width = 106;
        Height = 30;
        OutLineThick = 1;
        Displacement = 1;
        minUserX = OutLineThick;
        minUserY = OutLineThick;
        maxUserX = Width - OutLineThick - Displacement;
        maxUserY = Height - OutLineThick - Displacement;
    }

    public readonly int Width;
    public readonly int Height;
    public readonly int OutLineThick;
    public readonly int Displacement;
    public readonly int minUserX;
    public readonly int minUserY;
    public readonly int maxUserX;
    public readonly int maxUserY;
}