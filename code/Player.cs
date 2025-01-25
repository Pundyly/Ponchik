using Sandbox;

public sealed class Player : Component
{
	public Angles LookInput;
	protected override void OnUpdate()
	{
		// If we're a proxy then don't do any controls
		// because this client isn't controlling us
		if (IsProxy)
			return;

		// direction keys are pressed
		if (!Input.AnalogMove.IsNearZeroLength)
		{
			Transform.Position += Input.AnalogMove.Normal * Time.Delta * 100.0f;
		}

		if (Input.Down("jump"))
		{
			Transform.Position += Vector3.Forward * Time.Delta;
		}
		// position the camera
		var mouselook = Input.AnalogLook + 1;
		mouselook = (mouselook + Input.AnalogLook);
		

		var lookInput = (LookInput + Input.AnalogLook).Normal;
		GameObject.Transform.Rotation = LookInput;


		if(Input.Down("Run"))
        {
			Transform.Rotation = new Angles(0,90,0);
		}


		if (Input.Down("Duck"))
		{
			Transform.Rotation = new Angles(0, -90, 0);
		}
	}
}
