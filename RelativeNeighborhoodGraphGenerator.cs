using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace RelativeNeighborhoodGraph;

public static class RelativeNeighborhoodGraphGenerator
{
    public static List<Tuple<Vector2, Vector2>> Generate(IEnumerable<Vector2> points)
    {
        List<Tuple<Vector2, Vector2>> result = new();

        Parallel.ForEach(points, point =>
        {
            Parallel.ForEach(points, point2 =>
            {
                if (point == point2 || result.Contains(new Tuple<Vector2, Vector2>(point2, point)))
                {
                    return;
                }

                float distance = Vector2.DistanceSquared(point, point2);
                bool closest = true;

                Parallel.ForEach(points, (point3, state) =>
                {
                    if (point3 == point || point3 == point2)
                    {
                        return;
                    }

                    float distance2 = Vector2.DistanceSquared(point3, point);
                    float distance3 = Vector2.DistanceSquared(point3, point2);

                    if (distance > distance2 && distance > distance3)
                    {
                        closest = false;
                        state.Break();
                    }
                });

                if (closest)
                {
                    result.Add(new Tuple<Vector2, Vector2>(point, point2));
                }
            });
        });

        return result;
    }
}