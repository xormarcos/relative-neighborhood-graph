# Relative Neighborhood Graph
A class library for creating Relative Neighborhood Graphs in C#<br/>
https://en.wikipedia.org/wiki/Relative_neighborhood_graph<br/>

## Install

```
dotnet add package RelativeNeighborhoodGraph
```

## Usage

```csharp
using System;
using System.Collections.Generic;
using System.Numerics;
using RelativeNeighborhoodGraph;

List<Vector2> points = new() 
{
    new Vector2(0,1),
    new Vector2(1,0),
    new Vector2(3,1)
};

List<Tuple<Vector2,Vector2>> result = RelativeNeighborhoodGraphGenerator.Generate(points);
```

## Result

The result will be a list of vector pairs, which represent the connections.