using System;
using System.Collections.Generic;

namespace RelativeNeighborhoodGraph;

public static class RelativeNeighborhoodGraphGenerator
{
    public static List<Tuple<Vector2, Vector2>> Generate(IEnumerable<Vector2> points)
    {
        List<Tuple<Vector2, Vector2>> result = new List<Tuple<Vector2, Vector2>>();

        foreach (Vector2 point in points)
        {
            foreach (Vector2 point2 in points)
            {
                if (point.Equals(point2) || result.Contains(new Tuple<Vector2, Vector2>(point2, point)))
                {
                    continue;
                }

                double distance = point.DistanceTo(point2);
                bool closest = true;

                foreach (Vector2 point3 in points)
                {
                    if (point3.Equals(point) || point3.Equals(point2))
                    {
                        continue;
                    }

                    double distance2 = point3.DistanceTo(point);
                    double distance3 = point3.DistanceTo(point2);

                    if (distance > distance2 && distance > distance3)
                    {
                        closest = false;
                        break;
                    }
                }

                if (closest)
                {
                    result.Add(new Tuple<Vector2, Vector2>(point, point2));
                }
            }
        }

        return result;
    }
}

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