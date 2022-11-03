extends 'res://addons/gut/test.gd'

var character = load("res://Modules/CharacterController/CharacterController.cs")
var _character = character.new();

func test_some_method():
	var result = _character.some_method();
	assert_eq(result,"HolaMundo","El resultado debio ser HolaMundo");
	
func test_another_method():
	var result = _character.another_method();
	assert_eq(result,"HolaMundo","El resultado debio ser HolaMundo");
