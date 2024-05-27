namespace Fight_or_Die.Factory;

public interface IFactory<T>
{
    T Create();
}