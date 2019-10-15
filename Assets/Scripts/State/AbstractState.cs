using System;
using System.Collections.Generic;

namespace State
{

	public abstract class AbstractState
	{
		public abstract StateType Type { get; }
		public virtual void OnEnter() { }
		public virtual void OnUpdate() { }
		public virtual void OnExit() { }
	}
}
