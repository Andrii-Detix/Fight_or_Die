namespace Fight_or_Die.Input;

public class PlayerInputService : AbstractService
{
    public PlayerInputService(InputService inputService)
    {
        _inputService = inputService;
    }

    private readonly Dictionary<ConsoleKey, Action> _actions = new Dictionary<ConsoleKey, Action>();
    private readonly InputService _inputService;

    public void AddAction(ConsoleKey key, Action action)
    {
        if(!_actions.ContainsKey(key))
            _actions.Add(key, action);
    }

    public void RemoveAction(ConsoleKey key)
    {
        if (_actions.ContainsKey(key))
            _actions.Remove(key);
    }

    private void OnKeyPressed(ConsoleKey key)
    {
        if(_actions.ContainsKey(key))
            _actions[key].Invoke();
    }
    protected override void OnEnable()
    {
        _inputService.KeyPressed += OnKeyPressed;
    }

    protected override void OnDisable()
    {
        _inputService.KeyPressed -= OnKeyPressed;
    }
}