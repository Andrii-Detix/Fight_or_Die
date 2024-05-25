﻿namespace Fight_or_Die.GeometryElements;

public class Vector
{
    public Vector(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; private set; }
    public int Y { get; private set; }

    public static Vector operator +(Vector a, Vector b) => new Vector(a.X + b.X, a.Y + b.Y);
    public static Vector operator -(Vector a, Vector b) => new Vector(a.X - b.X, a.Y - b.Y);
    public static Vector operator *(int k, Vector vector) => new Vector(k * vector.X, k * vector.Y);

    public static Vector Up => new Vector(0, 1);
    public static Vector Down => new Vector(0, -1);
    public static Vector Forward => new Vector(1, 0);
    public static Vector Back => new Vector(-1, 0);
    public static Vector Zero => new Vector(0, 0);
}