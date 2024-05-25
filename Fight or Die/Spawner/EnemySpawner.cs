using Fight_or_Die.Factory;
using Fight_or_Die.GeometryElements;
using Fight_or_Die.Model.CharacterModel;
using Fight_or_Die.Model.MapModel;
using Fight_or_Die.Simulations;

namespace Fight_or_Die.Spawner;

public class EnemySpawner
{
    public EnemySpawner(EnemiesSimulation enemies, CharacterFactory enemyFactory, Map map, int spawnInterval,
        int maxEnemiesCount)
    {
        _enemies = enemies;
        _enemyFactory = enemyFactory;
        _map = map;
        _spawnInterval = spawnInterval;
        _maxEnemiesCount = maxEnemiesCount;
    }

    private readonly EnemiesSimulation _enemies;
    private readonly CharacterFactory _enemyFactory;
    private readonly Map _map;
    private readonly int _spawnInterval;
    private readonly int _maxEnemiesCount;

    private readonly Random _random = new Random();
    private int _spawnTimer = 0;
    private bool _canSpawn => (_enemies.Count < _maxEnemiesCount) && (_spawnTimer >= _spawnInterval);

    private void Spawn()
    {
        if (_canSpawn)
        {
            int plateNumber = _random.Next(_map.Count);
            Vector displacement = Vector.Down;
            Vector position = _map[plateNumber].Position + displacement;

            Character enemy = _enemyFactory.Create();
            enemy.SetPosition(position);
            _enemies.Simulate(enemy);

            _spawnTimer = 0;
            return;
        }

        _spawnTimer++;
    }

    public void Update()
    {
        Spawn();
    }
}