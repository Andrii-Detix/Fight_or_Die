using Fight_or_Die.Abstractions;
using Fight_or_Die.Model.HealthModel;

namespace Fight_or_Die.Model.CharacterModel;

public class Character : IDamagable
{
    public Character(int maxHealth)
    {
        Health = new Health(maxHealth);
    }
    
    public Health Health { get; }
    
    public void TakeDamage(int points)
    {
        Health.AddHealth(-points);
    }
}