namespace Fight_or_Die.Model.HealthModel;

public class Health
{
    public Health(int maxHealth)
    {
        _maxHealth = maxHealth;
        _health = _maxHealth;
    }

    private readonly int _maxHealth;
    private readonly int _minHealth = 0;
    private int _health;
    
    public event Action Died;
    public event Action HealthChanged;

    public void AddHealth(int points)
    {
        if(points == 0)
            return;

        int newHealth = _health + points;

        if (newHealth > _maxHealth)
            _health = _maxHealth;

        if (newHealth <= _minHealth)
        {
            _health = _minHealth;
            Died?.Invoke();
        }
        
        HealthChanged?.Invoke();
    }
}