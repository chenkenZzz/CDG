using System;
using System.Collections.Generic;
using UnityEngine;
using Hero;
using Enemy;
using State;

namespace Manager
{
	public class BattleFlowManager : MonoBehaviour
	{
		[SerializeField] private AbstractHero hero;
		[SerializeField] private List<AbstractEnemy> enemies;
		private StateManager stateManager;
		private Animator animator;

		public void Init(AbstractHero hero, params AbstractEnemy[] enemies)
		{
			//Component Setting
			animator = GetComponent<Animator>();

			this.hero = hero;
			for(var i = 0; i < enemies.Length; ++i)
			{
				this.enemies.Add(enemies[i]);
			}
			stateManager = new StateManager();
			MakeFSM();
			stateManager.Start(StateType.BATTLE_PREPARE);
		}

		public void OnUpdate()
		{
			stateManager.OnUpdate();

			CheckReason();
		}

		private void CheckReason()
		{
			if (IfAnimationIsOver("BattlePrepare"))
			{
				stateManager.Translate(StateType.BATTLE_PLAYER_TURN);
			}
		}

		private void MakeFSM()
		{
			stateManager.Add(new BattlePrepareState(animator));
		}

		private bool IfAnimationIsOver(string name)
		{
			return animator.GetCurrentAnimatorStateInfo(0).IsName(name) && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f;
		}

		public void Destroy()
		{
			hero = null;
			enemies = null;
			Destroy(gameObject);
		}
	}
}
