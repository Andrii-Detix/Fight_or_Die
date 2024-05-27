using System.Runtime.CompilerServices;

namespace Fight_or_Die.Configs;

public class ConsoleConfig
{
    public ConsoleConfig()
    {
    minUserX = OutLineThick;
    minUserY = OutLineThick;
    maxUserX = Width - OutLineThick - Displacement;
    maxUserY = Height - OutLineThick - Displacement;
    }
    public readonly int Width = 107;
    public readonly int Height = 30;
    public readonly int OutLineThick = 1;
    public readonly int Displacement = 1;
    public readonly int minUserX;
    public readonly int minUserY;
    public readonly int maxUserX;
    public readonly int maxUserY;
}