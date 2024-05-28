using Fight_or_Die.Files.Abstractions;
using Fight_or_Die.Files.Configs;
using Fight_or_Die.Files.GeometryElements;

namespace Fight_or_Die.Files.View;

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
        Vector position = new Vector(_consoleConfig.MinUserX, _consoleConfig.MinUserY);
        SetCursor(position);
        Console.WriteLine($"Health: {_health}");
    }
}