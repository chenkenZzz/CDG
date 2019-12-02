using System;
using System.Collections.Generic;
using UnityEngine;
using Card;

namespace Device
{
	public abstract class AbstractDevice
	{
		public virtual void Set(AbstractCard card) { }
		public abstract void Execute();
		public virtual void Reset() { }
	}
}
