using Godot;
using System;
using System.Collections.Generic;
using System.Threading;

public partial class WorldMap : Node
{
    [Export] float linkRange = 85000;


    Dictionary<int, WorldMapNode> worldMapNodes = new Dictionary<int, WorldMapNode>();








	AStar2D star = new AStar2D();








	Dictionary<Vector2I, Line2D> lines = new Dictionary<Vector2I, Line2D>();






	public override void _Ready()
	{
		CollectNodes();
        GenerateAStarGraph();
        DrawLines();
    }

	public void GenerateAStarGraph()
	{
	}

	public WorldMapNode GetClosestMapNode(Vector2 position)
	{
		var index = star.GetClosestPoint(position);

		if(index >= 0)
		{
			return worldMapNodes[(int)index];
		}
		return null;
	}

	public void CollectNodes()
	{
        worldMapNodes.Clear();

		int index = 0;
        foreach (var node in this.GetChildren())
        {
            if (node is WorldMapNode wmNode)
            {
                wmNode.SetWorldMapRef(this);
                wmNode.SetIndex(index);
                worldMapNodes.Add(index, wmNode);
                star.AddPoint(index, worldMapNodes[index].Position);
            }
        }
        for (var i = 0; i < worldMapNodes.Count; i++)
        {
            for (var j = 0; j < worldMapNodes.Count; j++)
            {
                if (worldMapNodes[i].Position.DistanceSquaredTo(worldMapNodes[j].Position) < linkRange * linkRange)
                {
                    star.ConnectPoints(i, j);
                }
            }
        }
    }

	public void DrawLines()
	{
		foreach (var line in lines)
		{
			line.Value.QueueFree();
		}
		lines.Clear();

		for (int i = 0; i < star.GetPointCount(); i++)
		{
			var connections = star.GetPointConnections(i);
			for (int j = 0; j < connections.Length; j++)
            {
				int connectionIndex = (int)connections[j];
                if (!lines.ContainsKey(new Vector2I(i, connectionIndex)))
                {
                    var newLine = new Line2D();
					newLine.Position = new Vector2();
                    //newLine.Position = (star.GetPointPosition(i) + star.GetPointPosition(j)) * 0.5f;
                    newLine.Points = new Vector2[]
                    {
                            star.GetPointPosition(i),
                            star.GetPointPosition(j),
                    };
                    lines.Add(new Vector2I(i, connectionIndex), new Line2D());
                    this.AddChild((Line2D)newLine);
                }
            }
		}
	}

	public void GetPath()
	{
         
	}
}