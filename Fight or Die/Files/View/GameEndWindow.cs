using Fight_or_Die.Configs;
using Fight_or_Die.GeometryElements;

namespace Fight_or_Die.View;

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

    public void DrawGameEnd()
    {
        int x = (_consoleConfig.maxUserX - _losingPhrase.Length) / 2;
        int y = _consoleConfig.maxUserY / 2;
        Vector position = new Vector(x, y);

        DrawStrings(position, _losingPhrase);
    }
}