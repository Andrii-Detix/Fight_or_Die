using Fight_or_Die.Files.Model.HealthModel;

namespace Fight_or_Die.Files.Abstractions;

public interface IHealable
{
    Health Health { get; }
    void Heal(int points);
}