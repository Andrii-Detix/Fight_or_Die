using Fight_or_Die.GeometryElements;

namespace Fight_or_Die.Model.PlateModel;

public class Plate
{
    public Plate(Vector position, Size size)
    {
        Position = position;
        Size = size;
    }

    public readonly Vector Position;
    public readonly Size Size;
}