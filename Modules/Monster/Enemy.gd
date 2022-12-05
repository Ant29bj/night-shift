extends KinematicBody

export var speed = 5

var path = []
var cur_path_idx = 0
var target = null
var velocity = Vector3.ZERO
var threshold = .1


onready var nav = get_parent()
#func _ready():
#	yield(owner, "ready")
#	target = owner.player
onready var scream = $AudioStreamPlayer3D
func _process(delta):
	rotate_y(1.5)

func _physics_process(delta):
	if path.size() > 0:
		move_to_target()
#		if path.size() == 1:
#			print("monstruo cerca de jugador")
#			Input.set_mouse_mode(Input.MOUSE_MODE_VISIBLE)			
#			get_tree().change_scene("res://Modules/GameOver/GameOver.tscn")
	
		
func move_to_target(): 
	if global_transform.origin.distance_to(path[cur_path_idx]) < threshold:
		path.remove(0)
		
	else:
		var direction = path[cur_path_idx] - global_transform.origin
		velocity = direction.normalized() * speed
		move_and_slide(velocity,Vector3.UP)
		


func get_target_path(target_pos):
	path = nav.get_simple_path(global_transform.origin, target_pos)
	

func _on_Timer_timeout():
	pass
	# get_target_path(target.global_transform.origin)
