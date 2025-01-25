using Sandbox;

public sealed class Camcontrol : Component
{
	[Property] public GameObject cam;
	private void OnStart()
	{
		cam.Transform.LocalPosition = new Vector3(-1000, 19, 575);
		//cam.Transform.Rotation = new Rotation(45, 45, 45, 180);
	}
}
