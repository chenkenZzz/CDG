using System;
using System.Collections.Generic;

namespace Action
{
	public abstract class AbstractAction
	{
		public abstract bool IsOver { get; }
		
		protected AbstractAction(){	}

		public abstract void Excute();
	}
}
