using Fight_or_Die.Configs;
using Fight_or_Die.GeometryElements;
using Fight_or_Die.Model.CharacterModel;

namespace Fight_or_Die.View;

public class PlayerView : AbstractView
{
    public PlayerView(Character player, ConsoleConfig consoleConfig) : base(consoleConfig)
    {
        _player = player;
        _texture = new[]
        {
            "<-_->",
            " ))  ",
            "/  \\ "
        };
    }

    private readonly Character _player;
    private readonly string[] _texture;


    public override void Show()
    {
        DrawPlayer();
        DrawHealth();
    }


    private void DrawPlayer()
    {
        DrawStrings(_player.Position, _texture);
    }

    private void DrawHealth()
    {
        Vector position = new Vector(_consoleConfig.maxUserX, _consoleConfig.minUserY);
        SetCursor(position);
        Console.WriteLine($"Health: {_player.Health.Value}");
    }
}