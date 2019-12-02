using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
			ObserveCard();
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

		private void ObserveCard()
		{

		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			Hand.observeDevice.Set(this);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			Hand.observeDevice.Reset();
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			
		}
	}
}
