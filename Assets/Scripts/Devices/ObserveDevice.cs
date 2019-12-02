using System;
using System.Collections.Generic;
using UnityEngine;
using Device;
using Card;


public class ObserveDevice : AbstractDevice
{
	private AbstractCard observeTarget;
	private AbstractCard lastObserveTarget;
	private bool isObserve = false;
	private bool isReseting = false;

	private float observeEnlargeTimer;
	private float observeEnlargeTime = 0.5f;
	private float targetScale = 1.3f;

	private float resetTimer;
	private float resetTime = 0.75f;
	private float resetScale;

	public ObserveDevice()
	{

	}
	public override void Execute()
	{
		if(isReseting)
		{
			if (resetTimer <= resetTime)
			{
				var value = Mathf.Lerp(lastObserveTarget.transform.localScale.x, resetScale, resetTimer / resetTime);
				lastObserveTarget.transform.localScale = new Vector2(value, value);

				resetTimer += Time.deltaTime;
			}
			else
			{
				lastObserveTarget.transform.localScale = new Vector2(resetScale, resetScale);
				isReseting = false;
				lastObserveTarget = null;
				resetTimer = 0f;
			}
		}

		if (isObserve)
		{
			if (observeEnlargeTimer <= observeEnlargeTime)
			{
				var value = Mathf.Lerp(observeTarget.transform.localScale.x, targetScale, observeEnlargeTimer / observeEnlargeTime);
				observeTarget.transform.localScale = new Vector2(value, value);

				observeEnlargeTimer += Time.deltaTime;			
			}
			else
			{
				observeEnlargeTimer = 0f;
				isObserve = false;
			}
		}
	}
	public override void Set(AbstractCard card)
	{
		observeTarget = card;
		resetScale = card.transform.localScale.x;
		isObserve = true;
	}

	public override void Reset()
	{
		lastObserveTarget = observeTarget;
		observeTarget = null;
		isReseting = true;
		isObserve = false;
		observeEnlargeTimer = 0f;
	}
}

