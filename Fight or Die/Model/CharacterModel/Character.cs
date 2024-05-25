using System.Runtime.CompilerServices;
using System.Threading.Channels;
using Fight_or_Die.Abstractions;
using Fight_or_Die.Model.HealthModel;

namespace Fight_or_Die.Model.CharacterModel;

public class Character : IDamagable
{
    public Character(int maxHealth)
    {
        Health = new Health(maxHealth);
        Enable();
    }

    public event Action<Character>? Died;
    public Health Health { get; }

    public void TakeDamage(int points)
    {
        Health.AddHealth(-points);
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