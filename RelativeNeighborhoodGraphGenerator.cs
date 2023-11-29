using System;
using System.Collections.Generic;
using System.Numerics;

namespace RelativeNeighborhoodGraph;

public static class RelativeNeighborhoodGraphGenerator
{
    public static IEnumerable<Tuple<Vector2, Vector2>> Generate(IEnumerable<Vector2> points)
    {
        HashSet<Tuple<Vector2, Vector2>> result = new();

        foreach (Vector2 point in points)
        {
            foreach (Vector2 point2 in points)
            {
                if (point.Equals(point2) || result.Contains(new Tuple<Vector2, Vector2>(point2, point)))
                {
                    continue;
                }

                double distance = Vector2.DistanceSquared(point, point2);
                bool closest = true;

                foreach (Vector2 point3 in points)
                {
                    if (point3.Equals(point) || point3.Equals(point2))
                    {
                        continue;
                    }

                    double distance2 = Vector2.DistanceSquared(point3, point);
                    double distance3 = Vector2.DistanceSquared(point3, point2);

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