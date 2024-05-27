using Fight_or_Die.Configs;
using Fight_or_Die.GeometryElements;
using Fight_or_Die.Model.PlateModel;

namespace Fight_or_Die.Model.MapModel;

public class MapBuilder
{
    public MapBuilder(ConsoleConfig config)
    {
        _config = config;
    }

    private readonly ConsoleConfig _config;

    public Map Create()
    {
        List<Plate> plates = new List<Plate>();
        
        Size plateSize = new Size(8, 1);
        
        Vector rowDisplacment = new Vector(plateSize.Width * 2, 0);
        Vector vertDisplacment = new Vector(0, 5);
        
        bool isIndentRow = false;

        Vector position = new Vector(_config.minUserX, _config.Height - _config.OutLineThick);
        
        while ((position - vertDisplacment).Y >= _config.minUserY)
        {
            position = isIndentRow
                ? new Vector(plateSize.Width, position.Y)
                : (new Vector(_config.minUserX, position.Y));
            
            while (position.X + plateSize.Width <= _config.maxUserX)
            {
                plates.Add(new Plate(position, plateSize));
                position += rowDisplacment;
            }

            position -= vertDisplacment;
            isIndentRow = !isIndentRow;
        }

        return new Map(plates);
    }
}