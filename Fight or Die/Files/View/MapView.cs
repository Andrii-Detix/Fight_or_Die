using Fight_or_Die.Files.Abstractions;
using Fight_or_Die.Files.Configs;
using Fight_or_Die.Files.GeometryElements;
using Fight_or_Die.Files.Model.PlateModel;

namespace Fight_or_Die.Files.View;

public class MapView : AbstractView
{
    public MapView(ConsoleConfig consoleConfig, IEnumerable<Plate> map) : base(consoleConfig)
    {
        _map = map;
    }

    private readonly IEnumerable<IPlaced> _map;
    private readonly char _texture = '\u2588';
    
    public override void Show()
    {
        DrawContours();
        DrawPlates();
    }

    private void DrawContours()
    {
        Size verticalContourSize = new Size(_consoleConfig.OutLineThick,
            _consoleConfig.Height);

        Size rowContourSize = new Size(_consoleConfig.Width - 2 * _consoleConfig.OutLineThick,
            _consoleConfig.OutLineThick);

        Vector position = new Vector(0, _consoleConfig.Height - _consoleConfig.OutLineThick);
        Fill(position, verticalContourSize, _texture);

        position = new Vector(_consoleConfig.Width - _consoleConfig.OutLineThick, position.Y);
        Fill(position, verticalContourSize, _texture);

        position = new Vector(_consoleConfig.OutLineThick, position.Y);
        Fill(position, rowContourSize, _texture);

        position = new Vector(position.X, _consoleConfig.OutLineThick - _consoleConfig.Displacement);
        Fill(position, rowContourSize, _texture);
    }

    private void DrawPlates()
    {
        foreach (var plate in _map)
        {
            Fill(plate.Position, plate.Size, _texture);
        }
    }
}