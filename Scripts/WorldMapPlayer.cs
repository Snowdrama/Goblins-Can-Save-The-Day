using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class WorldMapPlayer : CharacterBody2D
{
	[Export] WorldMap worldMap;


	Vector2 tartgetPosition;



	Vector2 currentPosition;
	[Export] float speed = 50;


	WorldMapNode currentWorldNode;
	public override void _Ready()
	{
        currentWorldNode = worldMap.GetClosestMapNode(tartgetPosition);
    }
	bool moving;
	public override void _Process(double delta)
	{
		if (moving)
		{
			currentPosition = currentPosition.MoveToward(currentWorldNode.Position, (float)delta * speed);
			this.Position = currentPosition;
			if (this.Position.DistanceTo(currentWorldNode.Position) <= 0.1f)
			{
				moving = false;
			}
        }


		Vector2 vel = new Vector2(0.3f, -0.5f).Normalized();


	}


	
	public override void _Input(InputEvent @event)
	{
		//var inputDirection = Input.GetVector("MoveLeft", "MoveRight", "MoveUp", "MoveDown", 0.1f);

		//var upVal = inputDirection.Dot(Vector2.Up);

		//GD.Print($"{inputDirection} Distance To {Vector2.Up} {upVal}");
		//if (!moving && inputDirection.Length() > 0.1f)
		//{
		//	if(currentWorldNode == null)
		//	{
		//              currentWorldNode = worldMap.GetClosestMapNode(tartgetPosition);
		//          }
		//	var nextNode = currentWorldNode.GetNodeInDirection(inputDirection.Normalized());
		//	if(nextNode != null)
		//	{
		//		currentWorldNode = nextNode;
		//		tartgetPosition = nextNode.Position;
		//		moving = true;
		//  }
		//}
    }
}
