extends ColorRect
#
#
## Declare member variables here. Examples:
## var a = 2
## var b = "text"
#onready var anim =$AnimationPlayer 
#
#
#var is_paused = false setget set_is_paused
#
#
#func _unhandled_input(event):
#	if event.is_action_pressed("ui_cancel"):
#		anim.play("Pause")
#		self.is_paused = !is_paused
##		if Input.set_mouse_mode(Input.MOUSE_MODE_VISIBLE):
##		else:
##			Input.set_mouse_mode(Input.MOUSE_MODE_VISIBLE)
#
#
#
#
#
#func set_is_paused(value):
#	is_paused = value
#	get_tree().paused = is_paused
#	visible = is_paused
#
## Called when the node enters the scene tree for the first time.
#
