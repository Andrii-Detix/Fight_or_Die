namespace Fight_or_Die.Files.Factory;

public interface IFactory<T>
{
    T Create();
}