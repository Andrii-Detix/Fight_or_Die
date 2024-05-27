using Fight_or_Die.Abstractions;
using Fight_or_Die.GeometryElements;

namespace Fight_or_Die.Model.Items;

public class Item : IPlaced
{
    public Item(int healPoints, Size size)
    {
        HealPoints = healPoints;
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
    public readonly int HealPoints;

    public void SetPosition(Vector position)
    {
        Position = position;
    }

    public void Use(IHealable target)
    {
        target.Heal(HealPoints);
        Destroyed?.Invoke(this);
    }
}