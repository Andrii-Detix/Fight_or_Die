namespace Fight_or_Die.Files.GameTime;

public class Time : ITime, ITimeListener
{
    public Time(int delay)
    {
        _delay = delay;
    }

    public event Action? Ticked;
    
    public int Frame { get; private set; } = 0;

    private readonly int _delay;

    public void Tick()
    {
        Thread.Sleep(_delay);
        Ticked?.Invoke();
        Frame++;
    }
}