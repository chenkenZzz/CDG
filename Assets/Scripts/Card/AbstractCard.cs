using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Msg;

namespace Card
{
	public abstract class AbstractCard : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler
	{
		private Image cardIllustration;
		private Text cardNameText;
		private Text cardDescriptionText;
		private Text cardCostText;

		protected abstract Sprite Illustration { get; }
		public abstract int Cost { get; }
		protected abstract string Name { get;}
		protected abstract string Description { get; }
		public abstract bool CanUpgrade { get; }
		public abstract bool CanUse { get; }
		public abstract AbstractCard Copy();
		public abstract void OnUse();
		public abstract void OnUpgrade();


		protected void Awake()
		{
			SetComponents();
		}

		protected void Update()
		{
			ShowInUI();
		}

		private void SetComponents()
		{
			cardIllustration = transform.GetChild(0).GetChild(0).GetComponent<Image>();
			cardNameText = transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>();
			cardDescriptionText = transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Text>();
			cardCostText = transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<Text>();
		}

		private void ShowInUI()
		{
			cardIllustration.sprite = Illustration;
			cardNameText.text = Name;
			cardDescriptionText.text = Description;
			cardCostText.text = Cost.ToString();
		}


		public void OnPointerEnter(PointerEventData eventData)
		{
			MessageCenter.Instance.SendMessage(
				new Message
				(
					MsgCode.MSG_ObserveCard, 
					new KeyValuePair<string, object>("Card", this)
				));
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			MessageCenter.Instance.SendMessage(
			new Message
			(
				MsgCode.MSG_DoNotObserveCard,
				new KeyValuePair<string, object>("Card", this)
			));
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			if(Input.GetMouseButtonDown(0))
			{
				MessageCenter.Instance.SendMessage(
				new Message
				(
					MsgCode.MSG_SeletCard,
					new KeyValuePair<string, object>("Card", this)
				));
			}
			else if(Input.GetMouseButtonDown(1))
			{
				MessageCenter.Instance.SendMessage(
				new Message
				(
					MsgCode.MSG_ConcellSelectCard
				));
			}
		}
	}
}
