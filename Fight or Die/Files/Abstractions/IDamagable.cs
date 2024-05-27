using Fight_or_Die.Model.HealthModel;

namespace Fight_or_Die.Abstractions;

public interface IDamagable
{
    Health Health { get; }
    void TakeDamage(int points);
}