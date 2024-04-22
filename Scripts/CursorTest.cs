using Godot;
using System;

public partial class CursorTest : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);


		if(@event is InputEventMouseButton buttonClick)
		{
			GD.Print($"Device {buttonClick.Device} Pressed the {buttonClick.ButtonIndex} button at {buttonClick.Position}");
		}
    }
}
