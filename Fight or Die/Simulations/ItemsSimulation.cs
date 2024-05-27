using Fight_or_Die.Model.CharacterModel;
using Fight_or_Die.Model.Items;

namespace Fight_or_Die.Simulations;

public class ItemsSimulation : AbstractSimulation<Item>
{
    public override void Simulate(Item item)
    {
        if(_entities.Contains(item))
            return;
        
        OnEnable(item);
        Add(item);
    }

    protected override void Stop(Item item)
    {
        if(!_entities.Contains(item))
            return;
        
        OnDisable(item);
        Remove(item);
    }

    private void OnEnable(Item item)
    {
        
    }

    private void OnDisable(Item item)
    {
        
    }
}