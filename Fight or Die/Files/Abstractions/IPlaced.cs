using Fight_or_Die.GeometryElements;

namespace Fight_or_Die.Abstractions;

public interface IPlaced
{
    Vector Position { get; }
    Size Size { get; }
}