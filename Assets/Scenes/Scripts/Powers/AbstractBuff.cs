using System;
using System.Collections.Generic;

namespace Buff
{
	public abstract class AbstractBuff
	{
		protected Status status = new Status();

		public abstract void Init();
		public virtual void OnPlayerTurnStart() { }
		public virtual void OnPlayerTurnEnd() { }
		public virtual void OnPlayerUseCard() { }
		public virtual void OnEnemiesTurnStart() { }
		public virtual void OnEnemiesTurnEnd() { }
		public virtual void OnDamageReceiveFromEnemies() { }
		public virtual void OnDamageTakeToEnemies() { }
		public virtual void OnRendering() { }
		public virtual void OnBuffCreate() { }
		public virtual void OnBuffDestroy() { }
	}
}

