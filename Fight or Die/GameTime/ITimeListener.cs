namespace Fight_or_Die.GameTime;

public interface ITimeListener
{
    event Action? Ticked;
    void Tick();
}