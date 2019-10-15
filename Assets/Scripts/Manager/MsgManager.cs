using System;
using System.Collections.Generic;

public delegate void OnMsgSendCallBack(Msg.Msg msg);

namespace Manager
{
	public class MsgManager : Singleton<MsgManager>
	{
		private Dictionary<MsgType, List<OnMsgSendCallBack>> msgs;


		public override void Init()
		{
			msgs = new Dictionary<MsgType, List<OnMsgSendCallBack>>();
		}

		public bool AddListener(MsgType type,OnMsgSendCallBack callBack)
		{
			if(callBack == null)
			{
				//DEBUG LOG

				return false;
			}

			msgs[type].Add(callBack);
			return true;
		}

		public bool RemoveListener(MsgType type, OnMsgSendCallBack callBack)
		{
			if(callBack == null)
			{
				//DEBUG LOG

				return false;
			}

			for (var i = 0; i < msgs[type].Count; ++i)
			{
				if (msgs[type][i].Method.Name == callBack.Method.Name)
				{
					msgs[type].RemoveAt(i);
					return true;
				}
			}
			return false;
		}

		public void Fire(Msg.Msg msg)
		{
			if(!msgs.ContainsKey(msg.Type))
			{
				//DEBUG LOG

				return;
			}
			var callBacks = msgs[msg.Type];
			for(var i = 0; i < callBacks.Count; ++i)
			{
				callBacks[i]?.Invoke(msg);
			}

			//DEBUG LOG

			
		}
	}
}
