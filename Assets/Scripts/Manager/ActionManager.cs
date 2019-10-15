using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Action;

//■■■■■■■■■■■■■■■■■■■■■■■■■■■
//■■                順番で実行する                ■■
//■■■■■■■■■■■■■■■■■■■■■■■■■■■
namespace Manager
{
	public class ActionManager : Singleton<ActionManager>
	{
		private Queue<AbstractAction> actionQueue;
		public int Count
		{
			get
			{
				return actionQueue.Count;
			}
		}
		public bool IsExcuting
		{
			get
			{
				return actionQueue.Peek() != null;
			}
		}

		public override void Init()
		{
			actionQueue = new Queue<AbstractAction>();
		}

		public void OnUpdate()
		{
			var current = actionQueue.Peek();
			if(current == null)
			{
				//DEBUG LOG

				return;
			}


			if (!current.IsOver)
			{
				current.Excute();
			}
			else
			{
				actionQueue.Dequeue();
			}
		}

		public void AddAction(AbstractAction action)
		{
			actionQueue.Enqueue(action);
		}

		public void CancelCurAction()
		{
			actionQueue.Dequeue();
		}
	}
}
