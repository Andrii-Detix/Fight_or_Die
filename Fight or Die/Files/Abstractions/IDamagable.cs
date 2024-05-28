using Fight_or_Die.Files.Model.HealthModel;

namespace Fight_or_Die.Files.Abstractions;

public interface IDamagable
{
    Health Health { get; }
    void TakeDamage(int points);
}