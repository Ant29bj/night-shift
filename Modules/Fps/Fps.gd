extends Control

func _process(delta):
	$Fps.text = str(Engine.get_frames_per_second())
	print($Fps.text)
