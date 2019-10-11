using System;
using System.Collections.Generic;
using UnityEngine;

namespace Action
{
	public class MoveCardAction : AbstractAction
	{
		private GameObject target;
		private Vector3 from;
		private Vector3 to;
		private float drawCardMoveTime;
		private float drawCardMoveDelay;

		public override bool IsOver
		{
			get
			{
				return drawCardMoveTime >= drawCardMoveDelay; 
			}
		}

		public MoveCardAction(GameObject target,Vector3 from, Vector3 to,float drawCardMoveDelay)
		{
			this.target = target;
			this.from = from;
			this.to = to;
			this.drawCardMoveDelay = drawCardMoveDelay;
		}
		public override void Excute()
		{
			if (!IsOver)
			{
				target.transform.position = Vector3.Lerp(from, to, drawCardMoveTime / drawCardMoveDelay);

				drawCardMoveTime += Time.deltaTime;
			}
			else
			{

			}
		}		
	}
}
