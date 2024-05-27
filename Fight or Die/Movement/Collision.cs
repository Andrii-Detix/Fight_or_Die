using Fight_or_Die.Abstractions;
using Fight_or_Die.Configs;
using Fight_or_Die.GeometryElements;

namespace Fight_or_Die.Movement;

public class Collision
{
    public Collision(ConsoleConfig consoleConfig)
    {
        _consoleConfig = consoleConfig;
    }

    private readonly ConsoleConfig _consoleConfig;
    private readonly List<IPlaced> _placedEntities = new List<IPlaced>();

    public void Add(IPlaced entity)
    {
        if(!_placedEntities.Contains(entity))
            _placedEntities.Add(entity);
    }

    public void Add(List<IPlaced> entities)
    {
        foreach (var entity in entities)
        {
            Add(entity);
        }
    }

    public void Remove(IPlaced entity)
    {
        if (_placedEntities.Contains(entity))
            _placedEntities.Remove(entity);
    }

    public void Remove(List<IPlaced> entities)
    {
        foreach (var entity in entities)
        {
            Remove(entity);
        }
    }

    public List<IPlaced> HasIntersectionWith(IPlaced target)
    {
        List<IPlaced> intersections = HasIntersectionWith(target.Position, target.Size);
        if (intersections.Contains(target))
            intersections.Remove(target);
        return intersections;
        
    }
    public List<IPlaced> HasIntersectionWith(Vector position, Size size)
    {
        List<IPlaced> intersections = new List<IPlaced>();

        foreach (var placedEntity in _placedEntities)
        {
            bool intersect = Intersection(position, size, placedEntity.Position, placedEntity.Size);
            if(intersect)
                intersections.Add(placedEntity);
        }

        return intersections;
    }

    public bool OutOfBounds(IPlaced target)
    {
        return OutOfBounds(target.Position, target.Size);
    }
    public bool OutOfBounds(Vector position, Size size)
    {
        int posX =position.X;
        int posY = position.Y;
        bool rowOut = posX < _consoleConfig.minUserX ||
                      posX + size.Width - _consoleConfig.Displacement > _consoleConfig.maxUserX;

        bool vertOut = posY > _consoleConfig.maxUserY ||
                       posY - size.Height + _consoleConfig.Displacement < _consoleConfig.minUserY;

        return rowOut || vertOut;
    }
    
    private bool Intersection(Vector firstObjPos, Size firstObjSize, Vector secondObjPos, Size secondObjSize)
    {
        int firstObjLastY = firstObjPos.Y - firstObjSize.Height + _consoleConfig.Displacement;
        int secondObjLastY = secondObjPos.Y - secondObjSize.Height + _consoleConfig.Displacement;

        return SegmentIntersection(firstObjPos.X, firstObjSize.Width, secondObjPos.X, secondObjSize.Width) &&
               SegmentIntersection(firstObjLastY, firstObjSize.Height, secondObjLastY, secondObjSize.Height);
    }

    private bool SegmentIntersection(float firstPos, float firstWidth, float secondPos, float secondWidth)
    {
        if (firstWidth < secondWidth)
        {
            (firstPos, secondPos) = (secondPos, firstPos);
            (firstWidth, secondWidth) = (secondWidth, firstWidth);
        }

        float firstEnd = firstPos + firstWidth - _consoleConfig.Displacement;
        float secondEnd = secondPos + secondWidth - _consoleConfig.Displacement;
        return InTheMiddle(firstPos, firstEnd, secondPos) || InTheMiddle(firstPos, firstEnd, secondEnd);
    }

    bool InTheMiddle(float from, float to, float middle)
    {
        if (from > to)
            (from, to) = (to, from);
        
        return middle >= from && middle <= to;
    }
}