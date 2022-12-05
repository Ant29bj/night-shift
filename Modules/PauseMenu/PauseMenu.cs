using Godot;
using System;


namespace PauseMenuName
{
	public class PauseMenu : ColorRect
	{

		public AnimationPlayer anim = null;


		public override void _Ready()
		{
			anim = GetNode<AnimationPlayer>("AnimationPlayer");
		}

		//  // Called every frame. 'delta' is the elapsed time since the previous frame.
		//  public override void _Process(float delta)
		//  {
		//      
		//  }
		private void _on_ExitButton_pressed()
		{
			GetTree().Quit();
		}

		// public void Pause()
		// {
		// 	anim.Play("Pause");
		// 	// GetTree().Paused = true;
		// 	GD.Print("ALGO");

		// }

	}





}




