using Fight_or_Die.Files.Configs;
using Fight_or_Die.Files.Model.CharacterModel;

namespace Fight_or_Die.Files.Factory;

public class CharacterFactory : IFactory<Character>
{
    public CharacterFactory(CharacterConfig config)
    {
        _config = config;
    }

    private readonly CharacterConfig _config;

    public Character Create()
    {
        return new Character(_config.MaxHealth, _config.Size);
    }
}