using Fight_or_Die.Files.Configs;
using Fight_or_Die.Files.GeometryElements;
using Fight_or_Die.Files.Model.PlateModel;

namespace Fight_or_Die.Files.Model.MapModel;

public class MapBuilder
{
    public MapBuilder(ConsoleConfig config)
    {
        _config = config;
        _plateSize = new Size(8, 1);
        _rowDisplacement = new Vector(_plateSize.Width * 2, 0);
        _vertDisplacement = new Vector(0, 7);
    }

    private readonly ConsoleConfig _config;
    private readonly Size _plateSize;
    private readonly Vector _rowDisplacement;
    private readonly Vector _vertDisplacement;

    public Map Create()
    {
        List<Plate> plates = new List<Plate>();

        bool isIndentRow = false;

        Vector position = new Vector(_config.MinUserX, _config.Height - _config.OutLineThick);

        while ((position - _vertDisplacement).Y >= _config.MinUserY)
        {
            position = isIndentRow
                ? new Vector(_config.MinUserX + _plateSize.Width, position.Y)
                : (new Vector(_config.MinUserX, position.Y));

            while (position.X + _plateSize.Width - _config.Displacement <= _config.MaxUserX)
            {
                plates.Add(new Plate(position, _plateSize));
                position += _rowDisplacement;
            }

            position -= _vertDisplacement;
            isIndentRow = !isIndentRow;
        }

        return new Map(plates);
    }
}