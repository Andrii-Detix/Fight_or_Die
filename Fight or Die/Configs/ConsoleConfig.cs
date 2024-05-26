using System.Runtime.CompilerServices;

namespace Fight_or_Die.Configs;

public class ConsoleConfig
{
    public ConsoleConfig()
    {
    minUserX = OutLineThick;
    minUserY = OutLineThick;
    maxUserX = ConsoleWidth - OutLineThick - Displacement;
    maxUserY = ConsoleHeight - OutLineThick - Displacement;
    }
    public readonly int ConsoleWidth = 100;
    public readonly int ConsoleHeight = 30;
    public readonly int OutLineThick = 1;
    public readonly int Displacement = 1;
    public readonly int minUserX;
    public readonly int minUserY;
    public readonly int maxUserX;
    public readonly int maxUserY;
}