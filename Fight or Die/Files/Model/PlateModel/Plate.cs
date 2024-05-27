using Fight_or_Die.Abstractions;
using Fight_or_Die.GeometryElements;

namespace Fight_or_Die.Model.PlateModel;

public class Plate : IPlaced
{
    public Plate(Vector position, Size size)
    {
        Position = position;
        Size = size;
    }

    public Vector Position { get; }
    public Size Size { get; }
}