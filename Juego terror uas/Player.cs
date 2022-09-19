using Godot;
using System;

public class Player : Sprite
{
	const float SPEED = 80;
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
 public override void _PhysicsProcess(float delta)
 {
	Vector2 Move = new Vector2(0,0);
	if(Input.IsActionPressed(InputConstants.walk_up))
	{
		Move.y -= 5;
	}
	if(Input.IsActionPressed(InputConstants.walk_down))
	{
		Move.y += 5;
	}
	if(Input.IsActionPressed(InputConstants.walk_right))
	{
		Move.x += 5;
	}  
	if(Input.IsActionPressed(InputConstants.walk_left))
	{
		Move.x -= 5;
	}
	  GlobalPosition += Move*SPEED*delta;
 }


}
