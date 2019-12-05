using System;
using System.Collections.Generic;
using UnityEngine;
using Device;
using Card;
using UnityEngine.UI;


public class ObserveDevice : AbstractDevice
{
	private AbstractCard observeTarget;
	private Queue<KeyValuePair<AbstractCard,float>> ObservedOverTargets;
	private bool isObserve = false;

	private float observeEnlargeTimer;
	private float observeEnlargeTime = 0.15f;
	private float targetFromScale;
	private float targetToScale = 1.3f;

	private float resetTimer;
	private float resetFromScale;
	private float resetToScale;

	public ObserveDevice()
	{
		resetToScale = 1f;
		ObservedOverTargets = new Queue<KeyValuePair<AbstractCard, float>>();
	}

	public override void Execute()
	{
		if(ObservedOverTargets.Count > 0)
		{
			if (resetTimer <= ObservedOverTargets.Peek().Value)
			{
				var value = Mathf.Lerp(resetFromScale, resetToScale, resetTimer / ObservedOverTargets.Peek().Value);
				ObservedOverTargets.Peek().Key.transform.localScale = new Vector2(value, value);

				resetTimer += Time.deltaTime;
			}
			else
			{
				ObservedOverTargets.Peek().Key.transform.localScale = new Vector2(resetToScale, resetToScale);
				ObservedOverTargets.Dequeue();
				resetTimer = 0f;
			}
		}

		if (isObserve)
		{
			if (observeEnlargeTimer <= observeEnlargeTime)
			{
				var value = Mathf.Lerp(targetFromScale, targetToScale, observeEnlargeTimer / observeEnlargeTime);
				observeTarget.transform.localScale = new Vector2(value, value);

				observeEnlargeTimer += Time.deltaTime;			
			}
			else
			{
				observeTarget.transform.localScale = new Vector2(targetToScale, targetToScale);
				observeEnlargeTimer = 0f;
				isObserve = false;
			}
		}
	}
	public override void Set(AbstractCard card)
	{
		observeTarget = card;
		targetFromScale = observeTarget.transform.localScale.x;
		observeEnlargeTimer = 0f;
		isObserve = true;
	}

	public override void Reset(AbstractCard card)
	{
		resetFromScale = card.transform.localScale.x;
		isObserve = false;

		var resetTime = Mathf.Abs(resetFromScale - resetToScale) / 0.3f * 0.15f + 0.00001f;

		ObservedOverTargets.Enqueue(new KeyValuePair<AbstractCard, float>(card, resetTime));
	}
}

