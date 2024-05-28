using Fight_or_Die.Files.Configs;
using Fight_or_Die.Files.GeometryElements;

namespace Fight_or_Die.Files.View;

public class GameEndWindow : AbstractView
{
    public GameEndWindow(ConsoleConfig consoleConfig) : base(consoleConfig)
    {
    }

    private readonly string[] _losingPhrase = { "GAME END" };

    public override void Show()
    {
        Console.Clear();
        DrawGameEnd();
    }

    private void DrawGameEnd()
    {
        int x = (_consoleConfig.MaxUserX - _losingPhrase.Length) / 2;
        int y = _consoleConfig.MaxUserY / 2;
        Vector position = new Vector(x, y);

        DrawStrings(position, _losingPhrase);
    }
}