using System;
using System.Collections.Generic;
using UnityEngine;
using Device;
using Card;

public class SelectDevice : AbstractDevice
{
	private AbstractCard selectCard;
	private bool isDeviceActive;

	private Vector3 resetPosition;
	private float resetTimer;
	private float resetTime = 0.75f;
	private bool isDeviceOverload = false;


	public override void Execute()
	{
		if (selectCard == null)
			return;

		if(isDeviceActive)
		{
			var mouseScreenPos = Input.mousePosition;
			selectCard.transform.position = mouseScreenPos;
		}
		else
		{
			if (resetTimer < resetTime)
			{
				selectCard.transform.position = Vector3.Lerp(selectCard.transform.position, resetPosition, resetTimer / resetTime);
				resetTimer += Time.deltaTime;
			}
			else
			{
				selectCard.transform.position = resetPosition;
				isDeviceOverload = false;
				selectCard = null;
				resetTimer = 0f;
			}
		}
	}

	public override void Set(AbstractCard card)
	{
		if (isDeviceOverload)
			return;

		if (isDeviceActive)
			return;

		selectCard = card;
		isDeviceActive = true;
		resetPosition = card.transform.position;
	}

	public override void Reset()
	{
		if (!isDeviceActive)
			return;

		isDeviceOverload = true;
		isDeviceActive = false;
	}
}
