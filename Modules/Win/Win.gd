extends Control

var timer = Timer.new()
# Declare member variables here. Examples:
# var a = 2
# var b = "text"


# Called when the node enters the scene tree for the first time.
func _ready():
	timer.connect("timeout",self,"goToCredits")
	timer.wait_time = 10
	timer.one_shot = true
	add_child(timer)
	timer.start()


func goToCredits():
	get_tree().change_scene("res://Modules/Credits/GodotCredits.tscn")
	
