using Godot;
using System;
using System.Collections.Generic;

public partial class WorldMapNode : Sprite2D
{
    int nodeIndex = -1;
    WorldMap mapRef;
    public void SetIndex(int nodeIndex)
    {
        this.nodeIndex = nodeIndex;
    }

    public void SetWorldMapRef(WorldMap mapRef)
    {
        this.mapRef = mapRef;
    }
    public void Interact()
    {
        
    }
}
