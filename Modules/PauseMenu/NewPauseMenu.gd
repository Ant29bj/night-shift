extends Control




#onready var animation = $PauseMenu/AnimationPlayer


var is_paused = false setget set_is_paused


func _unhandled_input(event):
	if event.is_action_pressed("ui_cancel"):
		self.is_paused = !is_paused
		if self.is_paused == true:
			Input.set_mouse_mode(Input.MOUSE_MODE_VISIBLE)
		else:
			Input.set_mouse_mode(Input.MOUSE_MODE_CAPTURED)
		


func set_is_paused(value):
	is_paused = value
	get_tree().paused = is_paused
	visible = is_paused

# Called when the node enters the scene tree for the first time.




func _on_ResumeBtn_pressed():
	self.is_paused = false
	if self.is_paused == true:
		Input.set_mouse_mode(Input.MOUSE_MODE_VISIBLE)
	else:
		Input.set_mouse_mode(Input.MOUSE_MODE_CAPTURED)


func _on_ExitBtn_pressed():
	get_tree().quit()


func _on_SettingsBtn_pressed():
	pass # Replace with function body.


func _on_MenuBtn_pressed():
	self.is_paused = false
	get_tree().change_scene("res://Modules/MainMenu/MainMenu.tscn")
