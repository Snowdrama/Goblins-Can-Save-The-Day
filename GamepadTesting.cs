using Godot;
using System;

public partial class GamepadTesting : Node
{

	[Export] UIRouter router;
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


		if (@event is InputEventKey key)
        {
            if (key.Keycode == Key.F1)
            {
                router.OpenRoute("F1");
            }
            if (key.Keycode == Key.F2)
            {
                router.OpenRoute("F2");
            }
            if (key.Keycode == Key.F3)
            {
                router.OpenRoute("F3");
            }
            if (key.Keycode == Key.F4)
            {
                router.OpenRoute("F4");
            }
        }
    }
}
