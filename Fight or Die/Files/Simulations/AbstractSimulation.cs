using System.Collections;

namespace Fight_or_Die.Simulations;

public abstract class AbstractSimulation<T> : IEnumerable<T>
{
    protected readonly List<T> _entities = new List<T>();

    protected void Add(T entity)
    {
        _entities.Add(entity);
    }

    protected void Remove(T entity)
    {
        _entities.Remove(entity);
    }

    public int Count => _entities.Count;

    public IEnumerator<T> GetEnumerator() => _entities.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _entities.GetEnumerator();

    public abstract void Simulate(T entity);
    protected abstract void Stop(T entity);
    public abstract void StopAll();
}