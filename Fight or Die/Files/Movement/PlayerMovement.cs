using Fight_or_Die.Files.Abstractions;
using Fight_or_Die.Files.GeometryElements;
using Fight_or_Die.Files.Model.CharacterModel;
using Fight_or_Die.Files.Model.Items;
using Fight_or_Die.Files.Model.PlateModel;

namespace Fight_or_Die.Files.Movement;

public class PlayerMovement : IMovement
{
    public PlayerMovement(Character player, Collision collision)
    {
        _collision = collision;
        _player = player;
        _direction = Vector.Zero;
        _inJump = false;
        _autoMoving = false;
    }

    private readonly Character _player;
    private readonly Collision _collision;

    private bool _inJump;
    private bool _autoMoving;
    private Vector _direction;

    public void Move()
    {
        RowMoving();
        if (_inJump)
            VerticalMoving();
        else
            TryToFall();
        IntersectItem();
    }

    public void Jump()
    {
        if (_inJump)
            return;

        _inJump = true;
        _direction += Vector.Down;
    }

    public void GoForward()
    {
        _direction = new Vector(Vector.Forward.X, _direction.Y);
    }

    public void GoBack()
    {
        _direction = new Vector(Vector.Back.X, _direction.Y);
    }

    public void AutoMoving()
    {
        _autoMoving = !_autoMoving;
    }

    private void RowMoving()
    {
        Vector rowVector = new Vector(_direction.X, 0);
        if (!_autoMoving)
            _direction = new Vector(0, _direction.Y);
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
        Vector verticalVector = new Vector(0, _direction.Y);
        Vector nextPosition = _player.Position + verticalVector;

        if (_collision.OutOfBounds(nextPosition, _player.Size))
        {
            if (verticalVector.Y > 0)
            {
                _direction = new Vector(_direction.X, 0);
                _inJump = false;
            }
            else
            {
                _direction = new Vector(_direction.X, -_direction.Y);
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
                _direction = new Vector(_direction.X, -_direction.Y);
            }
            else
            {
                _direction = new Vector(_direction.X, 0);
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

        _direction += Vector.Up;
        _inJump = true;
    }

    private void IntersectItem()
    {
        List<IPlaced> intersections = _collision.HasIntersectionWith(_player);

        foreach (var obj in intersections)
        {
            if (obj is Item item)
                item.Use(_player);
        }
    }
}