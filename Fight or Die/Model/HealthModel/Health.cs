namespace Fight_or_Die.Model.HealthModel;

public class Health
{
    public Health(int maxHealth)
    {
        _maxHealth = maxHealth;
        Value = _maxHealth;
    }

    private readonly int _maxHealth;
    private readonly int _minHealth = 0;
    public int Value { get; private set; }
    
    public event Action Died;
    public event Action HealthChanged;

    public void AddHealth(int points)
    {
        int newHealth = Value + points;

        if (newHealth > _maxHealth)
            newHealth = _maxHealth;
        
        if(newHealth == Value)
            return;

        if (newHealth <= _minHealth)
        {
            Value = _minHealth;
            Died?.Invoke();
            return;
        }

        Value = newHealth;
        HealthChanged?.Invoke();
    }
}