using Godot;
using System;

public partial class UIGrabFocusOnActive : Node
{
	[Export] public Control Control;
	public override void _Ready()
	{
		Control.VisibilityChanged += () =>
		{
			if (Control.Visible)
			{
				Control.GrabFocus();
			}
		};

	}
}