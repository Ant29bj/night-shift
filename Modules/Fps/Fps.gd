extends Control

func _process(_delta):
	$Fps.text = str(Engine.get_frames_per_second())
	# print($Fps.text)
