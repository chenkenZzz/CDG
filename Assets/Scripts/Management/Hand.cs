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
	private AbstractDevice sortingDevice;

	private void Awake()
	{
		observeDevice = new ObserveDevice();
		selectDevice = new SelectDevice();
		sortingDevice = new SortingDevice();

		MessageCenter.Instance.Subscribe(MsgCode.MSG_MouseHoverIntoCard, ObserveCard);
		MessageCenter.Instance.Subscribe(MsgCode.MSG_MouseHoverOutCard, DoNotObserveCard);
		MessageCenter.Instance.Subscribe(MsgCode.MSG_MouseLeftClickCard, SelectCard);
		MessageCenter.Instance.Subscribe(MsgCode.MSG_MouseRightClickCard, ConcellSelectCard);
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
		MessageCenter.Instance.Unsubscribe(MsgCode.MSG_MouseHoverIntoCard, ObserveCard);
		MessageCenter.Instance.Unsubscribe(MsgCode.MSG_MouseHoverOutCard, DoNotObserveCard);
		MessageCenter.Instance.Unsubscribe(MsgCode.MSG_MouseLeftClickCard, SelectCard);
		MessageCenter.Instance.Unsubscribe(MsgCode.MSG_MouseRightClickCard, ConcellSelectCard);
	}
}

