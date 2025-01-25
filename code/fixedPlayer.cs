using Sandbox;
using Sandbox.Citizen;
using System;
using System.Threading;
using System.Threading.Tasks;

public sealed class fixedPlayer : Component, Component.ITriggerListener
{
	public float multyplier;
	[Property] public GameObject cam;
	[Property] public int jumps;
	[Property] public int jumpsnow;
	[Property] public CharacterController cc;

	public void OnTriggerEnter(Collider other)
	{
		jumpsnow = 2;
	}

	protected override void OnStart()
    {
		this.Transform.LocalRotation = new Angles(0, 0, 0);
		jumpsnow = jumps;
		if (!IsProxy)
		{
			cam.Enabled = true;
		}
	}

	protected override void OnUpdate()
	{
		//var cc = CharacterController;
		if (IsProxy)
			return;
		if (Input.Down("Run"))
        {
			multyplier = 2f;
        }	
		else
        {
			multyplier = 1;

		}

		if (jumpsnow > 0 && Input.Pressed("jump"))
		{
			jumpsnow = jumpsnow - 1;
			Transform.Position += new Vector3(0, 0, 25);
		}

		if (!Input.AnalogMove.IsNearZeroLength)
		{
			Transform.Position += Input.AnalogMove.Normal * Time.Delta * 100.0f * multyplier;
		}

		/*
		if (Input.Down("jump") && jumpnow > 0)
		{
			jumpnow = jumpnow - 1;
			Transform.Position += new Vector3(0,0,5);
		}
		*/
		/*if (Input.Down("jump"))
		{
			Transform.Position += new Vector3(0, 0, 5);
		}
		*/

		if (Input.Down("reload"))
		{
			Transform.Rotation = new Angles(0, 0, 0);
		}

	}
}
