using System;
using System.Collections.Generic;
using UnityEngine;
using Card;
using Device;
using Msg;

public class Hand : MonoBehaviour
{
	private AbstractDevice observeDevice;
	private AbstractDevice selectDevice;

	private void Awake()
	{
		observeDevice = new ObserveDevice();
		selectDevice = new SelectDevice();

		MessageCenter.Instance.Subscribe(MsgCode.MSG_ObserveCard, ObserveCard);
		MessageCenter.Instance.Subscribe(MsgCode.MSG_DoNotObserveCard, DoNotObserveCard);
		MessageCenter.Instance.Subscribe(MsgCode.MSG_SeletCard, SelectCard);
		MessageCenter.Instance.Subscribe(MsgCode.MSG_ConcellSelectCard, ConcellSelectCard);
	}

	private void Update()
	{
		observeDevice.Execute();
		selectDevice.Execute();
	}

	private void ObserveCard(Message message)
	{
		var card = (AbstractCard)message["Card"];
		observeDevice.Set(card);
	}

	private void DoNotObserveCard(Message message)
	{
		var card = (AbstractCard)message["Card"];
		observeDevice.Reset(card);
	}

	private void SelectCard(Message message)
	{
		var card = (AbstractCard)message["Card"];
		selectDevice.Set(card);
	}

	private void ConcellSelectCard(Message message)
	{
		selectDevice.Reset();
	}

	public void OnDestroy()
	{
		MessageCenter.Instance.Unsubscribe(MsgCode.MSG_ObserveCard, ObserveCard);
		MessageCenter.Instance.Unsubscribe(MsgCode.MSG_DoNotObserveCard, DoNotObserveCard);
		MessageCenter.Instance.Unsubscribe(MsgCode.MSG_SeletCard, SelectCard);
		MessageCenter.Instance.Unsubscribe(MsgCode.MSG_ConcellSelectCard, ConcellSelectCard);
	}
}

