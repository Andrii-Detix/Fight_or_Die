using Fight_or_Die.Abstractions;
using Fight_or_Die.Configs;
using Fight_or_Die.GeometryElements;

namespace Fight_or_Die.View;

public class PlayerView : AbstractView
{
    public PlayerView(IPlaced player, int health, ConsoleConfig consoleConfig) : base(consoleConfig)
    {
        _player = player;
        _health = health;
        _texture = new[]
        {
            "<-_->",
            " ))  ",
            "/  \\ "
        };
    }

    private readonly IPlaced _player;
    private int _health;
    private readonly string[] _texture;


    public override void Show()
    {
        DrawPlayer();
        DrawHealth();
    }

    public void OnHealthChanged(int health)
    {
        _health = health;
    }

    private void DrawPlayer()
    {
        DrawStrings(_player.Position, _texture);
    }

    private void DrawHealth()
    {
        Vector position = new Vector(_consoleConfig.minUserX, _consoleConfig.minUserY);
        SetCursor(position);
        Console.WriteLine($"Health: {_health}");
    }
}