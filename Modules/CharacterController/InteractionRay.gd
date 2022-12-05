extends RayCast

onready var prompt = $Prompt
onready var winning = 0
# Declare member variables here. Examples:
# var a = 2
# var b = "text"


# Called when the node enters the scene tree for the first time.
func _ready():
	add_exception(owner)


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _physics_process(_delta):
	prompt.text =""
	if is_colliding():
		var detected = get_collider()
		
		if detected is Interactable:
			prompt.text = detected.getPrompt()
			if Input.is_action_just_pressed(detected.prompt_action):
				detected.interact(owner)
				winning = detected.callWin()
				
	if(winning == 4):
		get_tree().change_scene("res://Modules/Win/Win.tscn")


				
				
				
