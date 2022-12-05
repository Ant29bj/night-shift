extends RayCast

# Declare member variables here. Examples:
# var a = 2
# var b = "text"


# Called when the node enters the scene tree for the first time.
func _ready():
	add_exception(owner)


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _physics_process(_delta):
	if is_colliding():
		var detected = get_collider()
		var auxCharacater = detected.to_string()
		var auxCharacater2 = auxCharacater.split(":")
		
		print(auxCharacater2[0])
		if auxCharacater2[0] == "[KinematicBody":
#			detected.interactCharacter(owner)
			Input.set_mouse_mode(Input.MOUSE_MODE_VISIBLE)			
			get_tree().change_scene("res://Modules/GameOver/GameOver.tscn")
			
			
			


				
				
				
