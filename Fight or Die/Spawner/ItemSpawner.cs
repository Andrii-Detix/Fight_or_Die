﻿using Fight_or_Die.Factory;
using Fight_or_Die.GeometryElements;
using Fight_or_Die.Model.CharacterModel;
using Fight_or_Die.Model.Items;
using Fight_or_Die.Model.MapModel;
using Fight_or_Die.Simulations;

namespace Fight_or_Die.Spawner;

public class ItemSpawner
{
    public ItemSpawner(ItemsSimulation items, ItemFactory itemFactory, Map map, int spawnInterval,
        int maxItemsCount)
    {
        _items = items;
        _itemFactory = itemFactory;
        _map = map;
        _spawnInterval = spawnInterval;
        _maxItemsCount = maxItemsCount;
    }

    private readonly ItemsSimulation _items;
    private readonly ItemFactory _itemFactory;
    private readonly Map _map;
    private readonly int _spawnInterval;
    private readonly int _maxItemsCount;

    private readonly Random _random = new Random();
    private int _spawnTimer = 0;
    private bool _canSpawn => (_items.Count < _maxItemsCount) && (_spawnTimer >= _spawnInterval);

    private void Spawn()
    {
        if (_canSpawn)
        {
            int plateNumber = _random.Next(_map.Count);
            Vector displacement = Vector.Down;
            Vector position = _map[plateNumber].Position + displacement;

            Item item  = _itemFactory.Create();
            item.SetPosition(position);
            _items.Simulate(item);

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