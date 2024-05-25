using System.Collections;
using Fight_or_Die.Model.PlateModel;

namespace Fight_or_Die.Model.MapModel;

public class Map : IEnumerable<Plate>
{
    public Map(List<Plate> plates)
    {
        _plates = plates;
    }
    
    private readonly List<Plate> _plates;

    public int Count => _plates.Count;

    public Plate this[int i] => _plates[i];
    
    public IEnumerator<Plate> GetEnumerator() => _plates.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _plates.GetEnumerator();
}