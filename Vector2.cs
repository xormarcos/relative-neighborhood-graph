using System;

namespace RelativeNeighborhoodGraph;

public struct Vector2
{
    public readonly int x;
    public readonly int y;

    public Vector2(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public double DistanceTo(Vector2 vector2)
    {
        return Math.Sqrt(Math.Pow(vector2.x - x, 2) + Math.Pow(vector2.y - y, 2));
    }
}