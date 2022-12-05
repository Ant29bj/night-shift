extends KinematicBody


# Declare member variables here. Examples:
# var a = 2
# var b = "text"
onready var Pm = $PauseMenu

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


func _unhandled_input(event:InputEvent):
	if event.is_action_released("ui_cancel"):
		Pm.pause()
	

# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
