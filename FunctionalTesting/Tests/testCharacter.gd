extends 'res://addons/gut/test.gd'

var character = load("res://Modules/CharacterController/CharacterController.cs")
var _character = null;

var _Hp
var result



func before_each():
	_character = character.new();

func after_each():
	_character.free();

func test_InitialHp():
	
	_Hp = _character.Hp;
	var aux = _character.Hp;
	assert_eq(aux,100,"La vida inicial debe ser 100");


func test_takeSomeDamage():
	
	result = _character.takeDamage(15);
	assert_eq(result,85,"La vida deberia ser 85 despues de eso");



func test_belowZero():
	_character.Hp = 10;
	result = _character.takeDamage(15);
	assert_eq(_character.Hp,0,"La vida minima es 0");
	
func test_Jumping():
	result = _character.jumpTest();
	assert_eq(result,true,"Verifica si funciona el boton saltar");
