using Fight_or_Die.Files.Abstractions;
using Fight_or_Die.Files.Configs;

namespace Fight_or_Die.Files.PlayerDamager;

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

    public void Update()
    {
        MakeDamage();
    }

    private void MakeDamage()
    {
        _damageTimer++;

        if (_damageTimer == _config.DamageInterval)
        {
            _player.TakeDamage(_config.Damage);
            _damageTimer = 0;
        }
    }
}