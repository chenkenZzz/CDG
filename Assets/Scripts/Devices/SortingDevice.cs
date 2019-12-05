using System;
using System.Collections.Generic;
using UnityEngine;
using Card;
using Device;

public class SortingDevice : AbstractDevice
{
	private List<AbstractCard> cards;

	public SortingDevice()
	{
		cards = new List<AbstractCard>();
	}

	public override void Execute()
	{
		if(cards.Count > 0)
		{
			switch(cards.Count)
			{
				case 0:
					break;
				case 1:
					break;
				case 2:
					break;
				case 3:
					break;
				case 4:
					break;
				case 5:
					break;
				case 6:
					break;
				case 7:
					break;
				case 8:
					break;
				case 9:
					break;
				case 10:
					break;

				default:
					Debug.Log("WTF,How can you get so many cards?");
					break;
			}
		}
	}

	public override void Set(AbstractCard card)
	{
		
	}

	public override void Reset(AbstractCard card)
	{
		
	}
}
