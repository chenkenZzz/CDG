using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
	public abstract class AbstractEnemy : MonoBehaviour
	{
		protected Status status = new Status();

		public abstract void Init();
		public virtual void OnAttack() { }
		public virtual void OnDamage() { }
		public virtual void OnSpecialAct() { }
	}
}
