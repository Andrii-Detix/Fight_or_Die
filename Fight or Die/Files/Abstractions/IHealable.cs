using Fight_or_Die.Model.HealthModel;

namespace Fight_or_Die.Abstractions;

public interface IHealable
{
    Health Health { get; }
    void Heal(int points);
}