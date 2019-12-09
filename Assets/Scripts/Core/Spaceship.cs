using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
	private IControlDevice controlDevice;
	private SpaceshipStatus spaceshipStatus;
	public SpaceshipStatus SpaceshipStatus
	{
		get
		{
			return spaceshipStatus;
		}
	}

	public void Set(IControlDevice controlDevice,SpaceshipStatus spaceshipStatus)
	{
		this.controlDevice = controlDevice;
		this.spaceshipStatus = spaceshipStatus;
	}

  
    void Update()
    {
		controlDevice.Execute();
    }
}
