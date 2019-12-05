using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;

namespace Msg
{
	public delegate void OnMessageCallBack(Message message);
	public class MessageCenter : Singleton<MessageCenter>
	{
		private Dictionary<MsgCode, List<OnMessageCallBack>> msgCallbacks = new Dictionary<MsgCode, List<OnMessageCallBack>>();

		public override void Initialize()
		{
			
		}

		public void Subscribe(MsgCode msgCode,OnMessageCallBack callBack)
		{
			if(callBack == null)
			{
				return;
			}

			if(msgCallbacks.ContainsKey(msgCode))
			{
				msgCallbacks[msgCode].Add(callBack);
			}
			else
			{
				msgCallbacks.Add(msgCode, new List<OnMessageCallBack>());
				msgCallbacks[msgCode].Add(callBack);
			}
		}

		public void Unsubscribe(MsgCode msgCode, OnMessageCallBack callBack)
		{
			if(callBack == null)
			{
				return;
			}

			if(!msgCallbacks.ContainsKey(msgCode))
			{
				return;
			}

			if(!msgCallbacks[msgCode].Contains(callBack))
			{
				return;
			}

			msgCallbacks[msgCode].Remove(callBack);
			if(msgCallbacks.Count == 0)
			{
				msgCallbacks.Remove(msgCode);
			}
		}

		public void SendMessage(Message message)
		{
			var callBacks = msgCallbacks[message.MsgCode];

			if(callBacks != null)
			{
				for(var i = 0; i < callBacks.Count; ++i)
				{
					callBacks[i](message);
				}
			}
		}
	}
}
