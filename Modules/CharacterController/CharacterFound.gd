class_name InteractCharac
extends KinematicBody


# Declare member variables here. Examples:
# var a = 2
# var b = "text"


# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


func interactCharacter(body):
	print(body.name, " interacted!")
	Input.set_mouse_mode(Input.MOUSE_MODE_VISIBLE)			
	get_tree().change_scene("res://Modules/GameOver/GameOver.tscn")
	
