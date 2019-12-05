using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Msg
{
	public class Message
	{
		public MsgCode MsgCode { get; private set; }

		private Dictionary<string, object> datas = new Dictionary<string, object>();

		public Message(MsgCode msgCode)
		{
			MsgCode = msgCode;
		}

		public Message(MsgCode msgCode,params KeyValuePair<string,object>[] pairs)
		{
			MsgCode = msgCode;

			for(var i = 0; i < pairs.Length; ++i)
			{
				datas.Add(pairs[i].Key, pairs[i].Value);
			}
		}

		public object this[string dataName]
		{
			get
			{
				if(datas.ContainsKey(dataName))
				{
					return datas[dataName];
				}
				return null;
			}
		}

		public void Send()
		{
			MessageCenter.Instance.SendMessage(this);
		}
	}
}
