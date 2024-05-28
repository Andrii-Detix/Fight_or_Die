using Fight_or_Die.Files.GeometryElements;

namespace Fight_or_Die.Files.Abstractions;

public interface IPlaced
{
    Vector Position { get; }
    Size Size { get; }
}