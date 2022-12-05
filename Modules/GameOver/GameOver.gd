extends Control


# Declare member variables here. Examples:
# var a = 2
# var b = "text"


# Called when the node enters the scene tree for the first time.
func _ready():
	$AnimationPlayer.play("GameOver")

# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass


func _on_MenuBtn_pressed():
	get_tree().change_scene("res://Modules/MainMenu/MainMenu.tscn")


func _on_ExitBtn_pressed():
	get_tree().quit()
