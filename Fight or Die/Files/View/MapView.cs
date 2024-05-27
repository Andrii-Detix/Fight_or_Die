using Fight_or_Die.Configs;
using Fight_or_Die.GeometryElements;
using Fight_or_Die.Model.MapModel;
using Fight_or_Die.Model.PlateModel;

namespace Fight_or_Die.View;

public class MapView : AbstractView
{
    public MapView(ConsoleConfig consoleConfig, IEnumerable<Plate> map) : base(consoleConfig)
    {
        _map = map;
    }

    private readonly IEnumerable<Plate> _map;
    private readonly char _texture = '\u2588';


    public override void Show()
    {
        DrawConturs();
        DrawPlates();
    }

    private void DrawConturs()
    {
        Size verticalConturSize = new Size(_consoleConfig.OutLineThick,
            _consoleConfig.Height);

        Size rowConturSize = new Size(_consoleConfig.Width - 2 * _consoleConfig.OutLineThick,
            _consoleConfig.OutLineThick);

        Vector position = new Vector(0, _consoleConfig.Height - _consoleConfig.OutLineThick);
        Fill(position, verticalConturSize, _texture);
        
        position = new Vector(_consoleConfig.Width - _consoleConfig.OutLineThick, position.Y);
        Fill(position, verticalConturSize, _texture);
        
        position = new Vector(_consoleConfig.OutLineThick, position.Y);
        Fill(position, rowConturSize, _texture);
        
        position = new Vector(position.X, _consoleConfig.OutLineThick-_consoleConfig.Displacement);
        Fill(position, rowConturSize, _texture);
    }

    private void DrawPlates()
    {
        foreach (var plate in _map)
        {
            Fill(plate.Position, plate.Size, _texture);
        }
    }
}