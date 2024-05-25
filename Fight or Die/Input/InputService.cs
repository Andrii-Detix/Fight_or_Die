using Fight_or_Die.GameTime;

namespace Fight_or_Die.Input;

public class InputService : AbstractService
{
    public InputService(ITimeListener timeListener)
    {
        _timeListener = timeListener;
    }

    public event Action<ConsoleKey> KeyPressed;

    private readonly ITimeListener _timeListener;
    
    protected override void OnEnable()
    {
        _timeListener.Ticked += OnTicked;
    }

    protected override void OnDisable()
    {
        _timeListener.Ticked -= OnTicked;
    }

    private void OnTicked()
    {
        if(Console.KeyAvailable)
            KeyPressed?.Invoke(Console.ReadKey().Key);
    }
    
}