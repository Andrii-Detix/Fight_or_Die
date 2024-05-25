namespace Fight_or_Die.GameTime;

public class Time : ITime, ITimeListener
{
    public Time(int delay)
    {
        _delay = delay;
    }

    public int Frame { get; private set; } = 0;
    
    public event Action? Ticked;

    private readonly int _delay;
    
    public void Tick()
    {
        Thread.Sleep(_delay);
        Ticked?.Invoke();
        Frame++;
    }
}