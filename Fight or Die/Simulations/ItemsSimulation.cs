using Fight_or_Die.Model.CharacterModel;
using Fight_or_Die.Model.Items;

namespace Fight_or_Die.Simulations;

public class ItemsSimulation : AbstractSimulation<Item>
{
    public event Action<Item>? Start;
    public event Action<Item>? End;
    public override void Simulate(Item item)
    {
        if(_entities.Contains(item))
            return;
        
        OnEnable(item);
        Add(item);
        Start?.Invoke(item);
    }

    protected override void Stop(Item item)
    {
        if(!_entities.Contains(item))
            return;
        
        OnDisable(item);
        Remove(item);
        End?.Invoke(item);
    }

    private void OnEnable(Item item)
    {
        item.Destroyed += Stop;
    }

    private void OnDisable(Item item)
    {
        item.Destroyed -= Stop;
    }
}