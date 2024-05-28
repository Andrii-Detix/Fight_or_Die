using Fight_or_Die.Configs;
using Fight_or_Die.Files.Model.Items;

namespace Fight_or_Die.Files.Factory;

public class ItemFactory : IFactory<Item>
{
    public ItemFactory(ItemConfig itemConfig)
    {
        _itemConfig = itemConfig;
    }

    private readonly ItemConfig _itemConfig;

    public Item Create()
    {
        return new Item(_itemConfig.HealPoints, _itemConfig.Size);
    }
}