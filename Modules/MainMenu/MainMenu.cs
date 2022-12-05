using Godot;
using System;

public class MainMenu : Node
{

	public Control Menu = null;
	public Control Settings = null;
	public MenuButton MenuBtns = null;
	public Vector2 Prueba;



	public override void _Ready()
	{
		Input.MouseMode = Input.MouseModeEnum.Confined;

		Menu = GetNode<Control>("Menu");
		Settings = GetNode<Control>("MenuSettings");
		MenuBtns = GetNode<MenuButton>("MenuSettings/MarginContainer/VBoxContainer/ResolutionBtn");
		MenuBtns.GetPopup().Connect("id_pressed", this, "_on_item_pressed");
		// GD.Print("Iniciando Juego");
		// GD.Print("Windows Size: " + OS.WindowSize);
		// GD.Print("Screen display: " + OS.GetScreenSize());




	}

	public override void _Process(float delta)
	{

	}
	private void _on_ExitBtn_pressed()
	{
		GetTree().Quit();
	}
	private void _on_StartBtn_pressed()
	{
		GetTree().ChangeScene("res://Modules/Escuela/Escuela.tscn");
	}
	private void _on_SettingsBtn_pressed()
	{
		Menu.Hide();
		Settings.Show();
	}
	private void _on_BackBtn_pressed()
	{
		Settings.Hide();
		Menu.Show();
	}
	private void _on_FullscreenBtn_pressed()
	{
		OS.WindowFullscreen = !OS.WindowFullscreen;
	}

	private void _on_item_pressed(int id)
	{
		string prueba = MenuBtns.GetPopup().GetItemText(id);
		GD.Print("Cambiando Screen display");

		if (prueba == "1920x1080")
		{
			OS.WindowSize = new Vector2(1920, 1080);
			GD.Print("Windows Size: " + OS.WindowSize);
			GD.Print("Screen display: " + OS.GetScreenSize());


		}
		else if (prueba == "1600x900")
		{
			OS.WindowSize = new Vector2(1600, 900);
			GD.Print("Windows Size: " + OS.WindowSize);
			GD.Print("Screen display: " + OS.GetScreenSize());

		}
		else if (prueba == "1366x768")
		{
			OS.WindowSize = new Vector2(1366, 768);
			GD.Print("Windows Size: " + OS.WindowSize);
			GD.Print("Screen display: " + OS.GetScreenSize());

		}
		else if (prueba == "1280x720")
		{
			OS.WindowSize = new Vector2(1280, 720);
			GD.Print("Windows Size: " + OS.WindowSize);
			GD.Print("Screen display: " + OS.GetScreenSize());


		}


	}
	private void _on_HSlider_value_changed(float value)
	{
		AudioServer.SetBusVolumeDb(AudioServer.GetBusIndex("Master"), value);

	}


}






