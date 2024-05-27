using Fight_or_Die.Abstractions;
using Fight_or_Die.Configs;
using Fight_or_Die.Model.CharacterModel;

namespace Fight_or_Die.PlayerDamager;

public class Damager
{
    public Damager(IDamagable player, DamagerConfig config)
    {
        _player = player;
        _config = config;
    }
    
    private readonly IDamagable _player;
    private readonly DamagerConfig _config;
    private int _damageTimer = 0;

    public void Udpate()
    {
        MakeDamage();
    }
    private void MakeDamage()
    {
        _damageTimer++;
        
        if (_damageTimer ==_config.DamageInterval)
        {
            _player.TakeDamage(_config.Damage);
            _damageTimer = 0;
        }
    }
}