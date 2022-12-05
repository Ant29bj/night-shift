extends Spatial


onready var player = $CharacterController



func _on_Timer_timeout():
	get_tree().call_group("Enemy", "get_target_path",player.global_transform.origin)
