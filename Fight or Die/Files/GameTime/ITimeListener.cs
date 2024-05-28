namespace Fight_or_Die.Files.GameTime;

public interface ITimeListener
{
    event Action? Ticked;
    void Tick();
}