using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControlDevice : IControlDevice
{
	private Spaceship owner;
	public KeyboardControlDevice(Spaceship owner)
	{
		this.owner = owner;
	}
	public void Execute()
	{
		var horizontal = Input.GetAxis("Horizontal");
		owner.transform.position += horizontal * owner.SpaceshipStatus.spd * Time.deltaTime * Vector3.right;
	}
}
