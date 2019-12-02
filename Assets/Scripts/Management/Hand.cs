using System;
using System.Collections.Generic;
using UnityEngine;
using Card;
using Device;

public class Hand : MonoBehaviour
{
	public static AbstractDevice observeDevice;

	private void Awake()
	{
		observeDevice = new ObserveDevice();
	}

	private void Update()
	{
		observeDevice.Execute();
	}
}

