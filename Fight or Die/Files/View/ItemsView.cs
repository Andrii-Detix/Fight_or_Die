using Fight_or_Die.Abstractions;
using Fight_or_Die.Configs;

namespace Fight_or_Die.View;

public class ItemsView : AbstractView
{
    public ItemsView(List<IPlaced> items, ConsoleConfig consoleConfig) : base(consoleConfig)
    {
        items = items;
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

    private void DrawItems()
    {
        foreach (var item in _items)
        {
            DrawStrings(item.Position, _texture);
        }
    }
    
}