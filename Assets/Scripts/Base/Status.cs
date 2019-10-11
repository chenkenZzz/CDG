using System;
using System.Collections.Generic;
using UnityEngine;
using Attribute;

[Serializable]
public class Status
{
	[SerializeField] private Dictionary<AttributeType, object> attributes;

	public object this[AttributeType type]
	{
		get
		{
			if (attributes.ContainsKey(type))
				return attributes[type];
			return null;
		}
	}

	public Status()
	{
		attributes = new Dictionary<AttributeType, object>();
	}

	public void Add(AttributeType type,object obj)
	{
		if(obj == null)
		{
			//DEBUG LOG

			return;
		}
		if(attributes.ContainsKey(type))
		{
			//DEBUG LOG

			return;
		}
		attributes.Add(type, obj);
	}

	public void Remove(AttributeType type)
	{
		if(attributes.ContainsKey(type))
		{
			//DEBUG LOG

			return;
		}
		attributes.Remove(type);
	}
}

