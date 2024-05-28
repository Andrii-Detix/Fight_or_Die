using Fight_or_Die.Files.Configs;
using Fight_or_Die.Files.Factory;
using Fight_or_Die.Files.GeometryElements;
using Fight_or_Die.Files.Model.Items;
using Fight_or_Die.Files.Model.MapModel;
using Fight_or_Die.Files.Simulations;

namespace Fight_or_Die.Files.Spawner;

public class ItemSpawner
{
    public ItemSpawner(ItemsSimulation items, ItemFactory itemFactory, Map map, SpawnerConfig spawnerConfig)
    {
        _items = items;
        _itemFactory = itemFactory;
        _map = map;
        _spawnerConfig = spawnerConfig;
    }

    private readonly ItemsSimulation _items;
    private readonly ItemFactory _itemFactory;
    private readonly Map _map;
    private readonly SpawnerConfig _spawnerConfig;

    private readonly Random _random = new Random();
    private int _spawnTimer = 0;

    public void Update()
    {
        Spawn();
    }
    
    private void Spawn()
    {
        if (CanSpawn())
        {
            int plateNumber = _random.Next(_map.Count);
            Vector displacement = Vector.Down;
            Vector position = _map[plateNumber].Position + displacement;

            Item item = _itemFactory.Create();
            item.SetPosition(position);
            _items.Simulate(item);

            _spawnTimer = 0;
            return;
        }

        _spawnTimer++;
    }

    private bool CanSpawn()
    {
        return (_items.Count < _spawnerConfig.MaxItemsCount) && (_spawnTimer >= _spawnerConfig.SpawnInterval);
    }
    
}