using Fight_or_Die.Configs;
using Fight_or_Die.Files.Abstractions;

namespace Fight_or_Die.Files.View;

public class ItemsView : AbstractView
{
    public ItemsView(ConsoleConfig consoleConfig) : base(consoleConfig)
    {
        _items = new List<IPlaced>();
        _texture = new[]
        {
            "##",
            "##"
        };
    }

    private readonly List<IPlaced> _items;
    private readonly string[] _texture;


    public override void Show()
    {
        DrawItems();
    }

    public void AddItem(IPlaced item)
    {
        _items.Add(item);
    }

    public void RemoveItem(IPlaced item)
    {
        _items.Remove(item);
    }

    private void DrawItems()
    {
        foreach (var item in _items)
        {
            DrawStrings(item.Position, _texture);
        }
    }
}