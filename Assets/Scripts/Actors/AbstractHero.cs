using System;
using System.Collections.Generic;
using UnityEngine;


namespace Hero
{
	public abstract class AbstractHero : MonoBehaviour
	{
		protected Status status = new Status();

		public abstract void Init();
		public virtual void OnHeal() { }
		public virtual void OnAttack() { }
		public virtual void OnDamage() { }
		public virtual void OnRest() { }
	}
}
