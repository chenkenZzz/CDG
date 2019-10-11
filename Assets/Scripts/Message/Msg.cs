using System;
using System.Collections.Generic;
using Manager;


namespace Msg
{
	public class Msg
	{
		private Dictionary<string, object> datas;

		public MsgType Type { get; private set; }
		public object Sender { get; private set; }

		public object this[string name]
		{
			get
			{
				if(string.IsNullOrEmpty(name))
				{
					return null;
				}
				return datas[name];
			}
		}

		public Msg(MsgType type)
		{
			datas = new Dictionary<string, object>();
			Type = type;		
		}

		public Msg(MsgType type,object sender)
		{
			datas = new Dictionary<string, object>();
			Type = type;
			Sender = sender;
		}

		public Msg(MsgType type,object sender,params KeyValuePair<string,object>[] values)
		{
			datas = new Dictionary<string, object>();
			Type = type;
			Sender = sender;

			for(var i = 0; i < values.Length; ++i)
			{
				if(datas.ContainsKey(values[i].Key))
				{
					datas[values[i].Key] = values[i].Value;
				}
				else
				{
					datas.Add(values[i].Key, values[i].Value);
				}
			}
		}

		public void Send()
		{
			MsgManager.Instance.Excute(this);
		}
	}
}
