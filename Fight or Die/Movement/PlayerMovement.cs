using Fight_or_Die.Abstractions;
using Fight_or_Die.GeometryElements;
using Fight_or_Die.Model.CharacterModel;
using Fight_or_Die.Model.Items;
using Fight_or_Die.Model.PlateModel;

namespace Fight_or_Die.Movement;

public class PlayerMovement : IMovement
{
    public PlayerMovement(Character player, Collision collision)
    {
        _collision = collision;
        _player = player;
        Direction = Vector.Zero;
        _inJump = false;
        _autoMoving = false;
    }

    private readonly Character _player;
    private readonly Collision _collision;
    private bool _inJump;
    private bool _autoMoving;
    public Vector Direction { get; set; }

    public void Move()
    {
        RowMoving();
        if(_inJump)
            VerticalMoving();
        else
            TryToFall();
        IntersectItem();
    }

    private void RowMoving()
    {
        
        Vector rowVector = new Vector(Direction.X, 0);
        if(!_autoMoving)
            Direction = new Vector(0, Direction.Y);
        Vector nextPosition = _player.Position + rowVector;

        if (rowVector.X != 0)
            Thread.Sleep(0);
        if (_collision.OutOfBounds(nextPosition, _player.Size))
            return;
        
        List<IPlaced> intersections = _collision.HasIntersectionWith(nextPosition, _player.Size);

        foreach (var obj in intersections)
        {
            if (obj is Plate && obj != _player)
                return;
        }

        _player.SetPosition(nextPosition);
    }

    private void VerticalMoving()
    {
        Vector verticalVector = new Vector(0, Direction.Y);
        Vector nextPosition = _player.Position + verticalVector;

        if (_collision.OutOfBounds(nextPosition, _player.Size))
        {
            
            if (verticalVector.Y > 0)
            {
                Direction = new Vector(Direction.X, 0);
                _inJump = false;
            }
            else
            {
                Direction = new Vector(Direction.X, -Direction.Y);
                _inJump = false;
            }
            return;
        }
        
        List<IPlaced> intersections = _collision.HasIntersectionWith(nextPosition, _player.Size);

        IPlaced plate = null;

        foreach (var obj in intersections)
        {
            if (obj is Plate)
                plate = obj;
        }
    
        if (plate != null)
        {
            if (verticalVector.Y < 0)
            {
                nextPosition = new Vector(nextPosition.X, plate.Position.Y + _player.Size.Height);
                Direction = new Vector(Direction.X, -Direction.Y);
            }
            else
            {
                Direction = new Vector(Direction.X, 0);
                nextPosition = _player.Position;
                _inJump = false;
            }
        }
    
        _player.SetPosition(nextPosition);
    }

    private void TryToFall()
    {
        Vector lowerPosition = _player.Position + Vector.Up;

        if (_collision.OutOfBounds(lowerPosition, _player.Size)) 
            return;

        List<IPlaced> intersections = _collision.HasIntersectionWith(lowerPosition, _player.Size);
        
        foreach (var obj in intersections)
        {
            if (obj is Plate)
            {
                return;
            }
        }
        
        Direction += Vector.Up;
        _inJump = true;
    }

    private void IntersectItem()
    {
        List<IPlaced> intersections = _collision.HasIntersectionWith(_player);

        foreach (var obj in intersections)
        {
            if(obj is Item item)
                item.Use(_player);
        }
    }

    public void Jump()
    {
        if(_inJump)
            return;

        _inJump = true;
        Direction += Vector.Down;
    }

    public void SetRowDirection(Vector direction)
    {
        bool sameSign = direction.X > 0 && Direction.X > 0 || direction.X < 0 && Direction.X < 0;

        if (!sameSign)
            Direction = new Vector(direction.X, Direction.Y);
    }
    public void AutoMoving()
    {
        _autoMoving = !_autoMoving;
    }
}