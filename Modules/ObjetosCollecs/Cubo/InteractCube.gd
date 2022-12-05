class_name Interactable
extends StaticBody
const WinClass = preload("res://Modules/ObjetosCollecs/Win.gd")
onready var win = WinClass.new()
onready var enemspeed = $"../Navigation/Enemy"
export var prompt_message = "Interact"

export var prompt_action = "interact"

func getPrompt():
	var keyName = ""
	for action in InputMap.get_action_list(prompt_action):
		if action is InputEventKey:
			keyName = OS.get_scancode_string(action.scancode)
	return prompt_message + "\t[" + keyName + "]"


func interact(body):
	print(body.name, " interacted!")
	enemspeed.speed += 1
	print(enemspeed.speed)
	get_parent().remove_child(self)
	
	



func callWin():
	return win.addCollectible()
