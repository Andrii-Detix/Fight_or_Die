using Fight_or_Die.Abstractions;
using Fight_or_Die.GeometryElements;
using Fight_or_Die.Model.HealthModel;

namespace Fight_or_Die.Model.CharacterModel;

public class Character : IDamagable, IHealable, IPlaced
{
    public Character(int maxHealth, Size size)
    {
        Health = new Health(maxHealth);
        Size = size;
        Position = Vector.Zero;
        Enable();
    }

    public Character(int maxHealth, Size size, Vector position) : this(maxHealth, size)
    {
        Position = position;
    }

    public event Action<Character>? Died;
    public Health Health { get; }

    public Vector Position { get; private set; }
    public Size Size { get; }
     
    public void TakeDamage(int points)
    {
        Health.AddHealth(-points);
    }
    public void Heal(int points)
    {
        Health.AddHealth(points);
    }

    public void SetPosition(Vector position)
    {
        Position = position;
    }

    private void OnDied()
    {
        Died?.Invoke(this);
        Disable();
    }

    private void Enable()
    {
        Health.Died += OnDied;
    }

    private void Disable()
    {
        Health.Died -= OnDied;
    }
}