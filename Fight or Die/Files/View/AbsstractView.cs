using Fight_or_Die.Configs;
using Fight_or_Die.GeometryElements;

namespace Fight_or_Die.View;

public abstract class AbstractView : IView
{
    protected AbstractView(ConsoleConfig consoleConfig)
    {
        _consoleConfig = consoleConfig;
    }

    protected ConsoleConfig _consoleConfig;
    protected void SetCursor(Vector position)
    {
        Console.SetCursorPosition(position.X, position.Y);
    }
    
    protected void Fill(Vector from, Size size, char texture)
    {
        Vector position = from;
        for (int i = 0; i < size.Height; i++)
        {
            for (int j = 0; j < size.Width; j++)
            {
                SetCursor(position);
                Console.Write(texture);
                position += Vector.Forward;
            }
            position += Vector.Down;
            position += size.Width * Vector.Back;
        }
    }

    protected void DrawStrings(Vector from, string[] painting)
    {
        Vector position = new Vector(from.X, from.Y - painting.Length +_consoleConfig.Displacement);

        foreach (var str in painting)
        {
            SetCursor(position);
            Console.Write(str);
            position += Vector.Up;
        }
    }
    
    public abstract void Show();
}