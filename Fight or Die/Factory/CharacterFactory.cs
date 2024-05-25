using Fight_or_Die.Configs;
using Fight_or_Die.Model.CharacterModel;

namespace Fight_or_Die.Factory;

public class CharacterFactory : IFactory<Character>
{
    public CharacterFactory(CharacterConfig config)
    {
        _config = config;
    }

    private readonly CharacterConfig _config;

    public Character Create()
    {
        return new Character(_config.MaxHalth, _config.Size);
    }
}