using System;
using System.Collections.Generic;
using System.Numerics;

namespace RelativeNeighborhoodGraph;

public static class RelativeNeighborhoodGraphGenerator
{
    private static Dictionary<Tuple<Vector2, Vector2>, float> cachedDistances = new();

    public static List<Tuple<Vector2, Vector2>> Generate(IEnumerable<Vector2> points)
    {
        List<Tuple<Vector2, Vector2>> result = new List<Tuple<Vector2, Vector2>>();

        foreach (Vector2 point in points)
        {
            foreach (Vector2 point2 in points)
            {
                if (point == point2 || result.Contains(new Tuple<Vector2, Vector2>(point2, point)))
                {
                    continue;
                }

                float distance = GetDistance(point, point2);
                bool closest = true;

                foreach (Vector2 point3 in points)
                {
                    if (point3 == point || point3 == point2)
                    {
                        continue;
                    }

                    float distance2 = GetDistance(point3, point);
                    float distance3 = GetDistance(point3, point2);

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

    private static float GetDistance(Vector2 point1, Vector2 point2)
    {
        Tuple<Vector2, Vector2> key = new Tuple<Vector2, Vector2>(point1, point2);

        float distance;

        if (cachedDistances.TryGetValue(key, out distance))
        {
            return distance;
        }

        if (cachedDistances.TryGetValue(new Tuple<Vector2, Vector2>(point2, point1), out distance))
        {
            return distance;
        }

        distance = Vector2.DistanceSquared(point1, point2);

        cachedDistances.Add(key, distance);

        return distance;
    }
}