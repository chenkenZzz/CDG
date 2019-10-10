using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Relics
{
	public abstract class AbstractRelics
	{
		protected Status status = new Status();
		public abstract void Init();
		public virtual void OnPickUpRelics() { }
		public virtual void OnBattleStart() { }
		public virtual void OnBattleEnd() { }
		public virtual void OnPlayerTurnStart() { }
		public virtual void OnPlayerTurnEnd() { }
		public virtual void OnEnemiesTurnStart() { }
		public virtual void OnEnemiesTurnEnd() { }
		public virtual void OnBonfireRestEnd() { }
		public virtual void OnPlayerDeath() { }
		public virtual void OnDamageReceiveFromEnemies() { }
		public virtual void OnDamageTakeToEnemies() { }
		public virtual void OnRendering() { }
	}
}
