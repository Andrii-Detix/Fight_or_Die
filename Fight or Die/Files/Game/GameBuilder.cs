using Fight_or_Die.Files.Configs;
using Fight_or_Die.Files.Factory;
using Fight_or_Die.Files.GameTime;
using Fight_or_Die.Files.GeometryElements;
using Fight_or_Die.Files.Input;
using Fight_or_Die.Files.Model.CharacterModel;
using Fight_or_Die.Files.Model.MapModel;
using Fight_or_Die.Files.Movement;
using Fight_or_Die.Files.PlayerDamager;
using Fight_or_Die.Files.Simulations;
using Fight_or_Die.Files.Spawner;
using Fight_or_Die.Files.View;

namespace Fight_or_Die.Files.Game;

public class GameBuilder
{
    private Time _time;

    private ConsoleConfig _consoleConfig;
    private CharacterConfig _characterConfig;
    private DamagerConfig _damagerConfig;
    private ItemConfig _itemConfig;
    private SpawnerConfig _spawnerConfig;

    private InputService _inputService;
    private PlayerInputService _playerInput;

    private Character _player;
    private ItemsSimulation _items;

    private Map _map;
    
    private Collision _collision;
    private PlayerMovement _playerMovement;

    private Damager _damager;

    private ItemSpawner _spawner;

    private CharacterFactory _characterFactory;
    private ItemFactory _itemFactory;

    private MapView _mapView;
    private ItemsView _itemsView;
    private PlayerView _playerView;
    private GameEndWindow _gameEndWindow;

    private bool _isRunning;
    
    
    public void Run()
    {
        Build();
        _isRunning = true;
        while (_isRunning)
        {
            _time.Tick();
        }
        _gameEndWindow.Show();
        Console.ReadKey();
    }

    private void Stop()
    {
        _isRunning = false;
        _inputService.Disable();
    }
    
    private void Build()
    {
        CreateTime();
        CreateConfigs();
        ConsoleConfigure();
        CreateFactories();
        CreatePlayer();
        CreateItemsSimulation();
        MapCreate();
        SpawnerCreate();
        CreateCollision();
        CreatePlayerMovement();
        CreateDamager();
        CreateInput();
        AddInputActions();
        CreateView();
        Enable();
    }

    private void CreateTime()
    {
        const int fps = 60;
        const int ms = 1000;
        _time = new Time(ms / fps);
    }

    private void CreateConfigs()
    {
        _consoleConfig = new ConsoleConfig();
        _characterConfig = new CharacterConfig();
        _damagerConfig = new DamagerConfig();
        _itemConfig = new ItemConfig();
        _spawnerConfig = new SpawnerConfig();
    }

    private void ConsoleConfigure()
    {
        Console.SetWindowSize(_consoleConfig.Width, _consoleConfig.Height);
        Console.SetBufferSize(_consoleConfig.Width, _consoleConfig.Height);
    }

    private void CreateFactories()
    {
        _characterFactory = new CharacterFactory(_characterConfig);
        _itemFactory = new ItemFactory(_itemConfig);
    }

    private void CreatePlayer()
    {
        Vector startPosition = new Vector(_consoleConfig.minUserX, _consoleConfig.maxUserY);
        _player = _characterFactory.Create();
        _player.SetPosition(startPosition);
    }

    private void CreateItemsSimulation()
    {
        _items = new ItemsSimulation();
    }

    private void MapCreate()
    {
        _map = new MapBuilder(_consoleConfig).Create();
    }

    private void SpawnerCreate()
    {
        _spawner = new ItemSpawner(_items, _itemFactory, _map, _spawnerConfig);
    }

    private void CreateCollision()
    {
        _collision = new Collision(_consoleConfig);

        foreach (var plate in _map)
        {
            _collision.Add(plate);
        }
    }

    private void CreatePlayerMovement()
    {
        _playerMovement = new PlayerMovement(_player, _collision);
    }

    private void CreateDamager()
    {
        _damager = new Damager(_player, _damagerConfig);
    }

    private void CreateInput()
    {
        _inputService = new InputService(_time);
        _playerInput = new PlayerInputService(_inputService);
    }

    private void AddInputActions()
    {
        _playerInput.AddAction(ConsoleKey.W, _playerMovement.Jump);
        _playerInput.AddAction(ConsoleKey.A, _playerMovement.GoBack);
        _playerInput.AddAction(ConsoleKey.D, _playerMovement.GoForward);
        _playerInput.AddAction(ConsoleKey.F, _playerMovement.AutoMoving);
    }

    private void CreateView()
    {
        _mapView = new MapView(_consoleConfig, _map);
        _playerView = new PlayerView(_player, _player.Health.Value, _consoleConfig);
        _itemsView = new ItemsView(_consoleConfig);
        _gameEndWindow = new GameEndWindow(_consoleConfig);
    }

    private void ViewUpdate()
    {
        Console.Clear();
        _mapView.Show();
        _itemsView.Show();
        _playerView.Show();
    }

    private void Enable()
    {
        _playerInput.Enable();
        _inputService.Enable();
        
        _items.Start += _collision.Add;
        _items.End += _collision.Remove;
        
        _items.Start += _itemsView.AddItem;
        _items.End += _itemsView.RemoveItem;

        _player.HealthChanged += _playerView.OnHealthChanged;

        _time.Ticked += _playerMovement.Move;
        _time.Ticked += _spawner.Update;
        _time.Ticked += _damager.Udpate;

        _time.Ticked += ViewUpdate;

        _player.Died += _items.StopAll;
        _player.Died += Disable;
        _player.Died += Stop;
    }

    private void Disable()
    {
        _playerInput.Disable();
        _inputService.Disable();
        
        _items.Start -= _collision.Add;
        _items.End -= _collision.Remove;
        
        _items.Start -= _itemsView.AddItem;
        _items.End -= _itemsView.RemoveItem;

        _player.HealthChanged -= _playerView.OnHealthChanged;

        _time.Ticked -= _playerMovement.Move;
        _time.Ticked -= _spawner.Update;
        _time.Ticked -= _damager.Udpate;

        _time.Ticked -= ViewUpdate;

        _player.Died -= _items.StopAll;
        _player.Died -= Disable;
        _player.Died -= Stop;
    }
}
