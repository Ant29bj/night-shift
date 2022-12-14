using Godot;
using System;
using transform;
public class CharacterController : KinematicBody
{
	//Variables Exportadas
	[Export(PropertyHint.Range, "0.1,10.0,0.1")] public float speed = 5.0f;
	[Export(PropertyHint.Range, "0.1,10.0,0.1")] public float SprintSpeed = 10.0f;

	[Export] public float acceleration = 1.0f / 0.5f;
	[Export] public float stoppingAcceleration = 10.0f;
	[Export] public float mouseSensivity = 0.003f;

	[Export] public float jumpHeight = 4.0f;
	[Export] public float jumpMaxDistance = 8.0f;

	//Miembros Internos
	private Vector3 velocity = Vector3.Zero;
	private float gravity;
	private float jumpInitialVelocity;

	private int Hp = 100;
	private int Stamina = 100;

	//Miembros de escena principal
	private Camera camera = null;
	private Spatial cameraY = null;
	public Spatial spotlight = null;
	public Spatial viewpoint = null;

	// public AudioStreamPlayer3D walk = null;
	// public AudioStreamPlayer3D phone = null;

	public AnimationPlayer characterAnim = null;
//	public AnimationPlayer MenuAnimation = null;

	public ColorRect PauseM = null;




	public override void _Ready()
	{
		//Invocado cuando el nodo es agregado y los hijos estan inicializados
		Input.MouseMode = Input.MouseModeEnum.Captured;
		camera = GetNode<Camera>("CameraRig/Yrotation/Camera");
		cameraY = GetNode<Spatial>("CameraRig/Yrotation");
		spotlight = GetNode<Spatial>("CameraRig/Yrotation/Camera/Celular/Cel/SpotLight");
		// walk = GetNode<AudioStreamPlayer3D>("AudioStreamPlayer3D");
		// phone = GetNode<AudioStreamPlayer3D>("CameraRig/Yrotation/Camera/Celular/Cel/AudioStreamPlayer3D");
		characterAnim = GetNode<AnimationPlayer>("AnimationPlayer");
		viewpoint = GetNode<Spatial>("Armature");
//		PauseM = GetNode<ColorRect>("PauseMenu");

		characterAnim.Play("Idle-loop");

		jumpHeight = jumpHeight / 2.0f;
		gravity = (-2.0f * jumpHeight * Mathf.Pow(SprintSpeed, 2.0f)) / Mathf.Pow(jumpMaxDistance, 2.0f);
		jumpInitialVelocity = -gravity * (jumpMaxDistance / SprintSpeed);
	}

	public override void _Process(float delta)
	{
		// GD.Print("Velocity Y ",velocity.y);
		// GD.Print("Velocity ",velocity);


		//Invocado cada frame, obtiene el input y maneja la velocidad

		//Obtiene el input principal
		var input = Input.GetVector("walk_left", "walk_right", "walk_up", "walk_down");
		//Inicializacion de variables de ayuda
		var target_velocity = new Vector3();
		var utrans = new UTransform(camera.GlobalTransform);




		var CurrentSpeed = speed;
		if (Input.IsActionPressed("sprint"))
		{
			CurrentSpeed = SprintSpeed;
			characterAnim.Play("Running-loop");
		}
		if (input.x == 0 && input.y == 0)
		{
			characterAnim.Play("Idle-loop");

		}
		if (Input.IsActionJustPressed("walk_left") || Input.IsActionJustPressed("walk_right") || Input.IsActionJustPressed("walk_up") || Input.IsActionJustPressed("walk_down"))
		{
			characterAnim.Play("walking-loop");
		}


		//se aplican cambios a la velocidad deseada para la direccion relativa
		target_velocity += utrans.Right * input.x;


		target_velocity += utrans.Forward * input.y;
		target_velocity.y = 0.0f;
		target_velocity = target_velocity.Normalized() * CurrentSpeed;
		target_velocity.y = velocity.y;

		// se prepara la aceleracion dinamica
		var target_acceleration = acceleration;
		if (target_velocity.LengthSquared() <= 0.1f)
		{
			target_acceleration = stoppingAcceleration;
		}

		// Cambios del usuario para cambiar la velocidad facilmente
		velocity = velocity.LinearInterpolate(target_velocity, target_acceleration * delta);

		if (!IsOnFloor())
		{
			velocity.y += gravity * delta;

		}
		else
		{
			velocity.y = 0.0f;
		}

		if (Input.IsActionPressed("jump") && IsOnFloor() && velocity.y <= 0.0f)
		{
			velocity.y = jumpInitialVelocity;
		}
		if (Input.IsActionJustPressed("jump"))
		{
			characterAnim.Play("Jumping");
		}
		if (Input.IsActionJustReleased("jump") && !IsOnFloor() && velocity.y >= 0.0)
		{
			velocity.y = 0.0f;

		}
		if (Input.IsActionJustPressed("flashlight") && spotlight.Visible)
		{
			spotlight.Visible = false;

		}
		else if (Input.IsActionJustPressed("flashlight") && !spotlight.Visible)
		{
			spotlight.Visible = true;

		}
//		if (Input.IsActionPressed("ui_cancel"))
//		{
//
//			PauseM.Call("pause");
//		}



	}
	public override void _Input(InputEvent e)
	{   // se invoca una vez por evento de input que es generado por godot

		if (e is InputEventMouseMotion && Input.MouseMode == Input.MouseModeEnum.Captured)
		{   //checa que se capture el input del mouse

			var m_event = e as InputEventMouseMotion;// se prepara para usar
			Vector2 motion = m_event.Relative * mouseSensivity * -1.0f; // se aplica escala y se invierte vector

			// se rota el nodo de camara basado en el vector escalado
			cameraY.RotateY(motion.x);
			camera.RotateX(motion.y * -1);
			viewpoint.RotateY(motion.x);


			var camRot = camera.RotationDegrees;
			camRot.x = Mathf.Clamp(camRot.x, -70.0f, 70.0f);
			camera.RotationDegrees = camRot;

			// if (e.IsActionPressed("ui_cancel"))
			// {//checa si llamamos el ui_cancel input

			// 	//usa un operador terciario para asignar el modo del mouse
			// 	Input.MouseMode = (Input.MouseMode == Input.MouseModeEnum.Captured ? Input.MouseModeEnum.Visible : Input.MouseModeEnum.Captured);
			// }
		}
	}




	public bool jumpTest()
	{
		bool prueba;
		Input.ActionPress("jump");
		prueba = Input.IsActionPressed("jump");
		return prueba;
	}
	public int takeDamage(int MonsterHit)
	{

		Hp = Hp - MonsterHit;
		if (Hp < 0)
		{
			Hp = 0;
		}
		return Hp;
	}


	public override void _PhysicsProcess(float delta)
	{//invocado una vez cada frame de fisicas, por predeterminado es 60fps se puede cambiar en las opciones del proyecto

		//usa funciones ya echas para mover al personaje y darle la velocidad restante a la variable
		velocity = MoveAndSlide(velocity, Vector3.Up, true, 4, Mathf.Deg2Rad(45.0f));
		//GD.Print(velocity);
	}
}
