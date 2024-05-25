using Fight_or_Die.Model.CharacterModel;

namespace Fight_or_Die.Simulations;

public class EnemiesSimulation : AbstractSimulation<Character>
{
    public override void Simulate(Character character)
    {
        if(_entities.Contains(character))
            return;
        
        OnEnable(character);
        Add(character);
    }

    protected override void Stop(Character character)
    {
        if(!_entities.Contains(character))
            return;
        
        OnDisable(character);
        Remove(character);
    }

    private void OnEnable(Character character)
    {
        character.Died += Stop;
    }

    private void OnDisable(Character character)
    {
        character.Died -= Stop;
    }
}