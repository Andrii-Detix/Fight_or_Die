using Fight_or_Die.Files.Abstractions;
using Fight_or_Die.Files.GeometryElements;

namespace Fight_or_Die.Files.Model.Items;

public class Item : IPlaced
{
    public Item(int healPoints, Size size)
    {
        _healPoints = healPoints;
        Size = size;
        Position = Vector.Zero;
    }

    public Item(int healPoints, Size size, Vector position) : this(healPoints, size)
    {
        Position = position;
    }

    public event Action<Item>? Destroyed;
    public Vector Position { get; private set; }
    public Size Size { get; }

    private readonly int _healPoints;

    public void SetPosition(Vector position)
    {
        Position = position;
    }

    public void Use(IHealable target)
    {
        target.Heal(_healPoints);
        Destroyed?.Invoke(this);
    }
}