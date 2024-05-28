using Fight_or_Die.Files.Abstractions;
using Fight_or_Die.Files.GeometryElements;

namespace Fight_or_Die.Files.Model.PlateModel;

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