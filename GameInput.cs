using Godot;
using System;

public enum InputType
{
	None,
	KBM,
	Gamepad,
}
public partial class GameInput : Node
{

	public InputType lastInput;
	public override void _Ready()
	{

	}



	public override void _Process(double delta)
	{
		
	}

    public override void _Input(InputEvent @event)
    {
		//let's start by capturing hardware input
		

		//then we can output custom devices
    }
}
