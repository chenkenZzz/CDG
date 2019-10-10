using System;
using System.Collections.Generic;
using UnityEngine;
using Hero;
using Enemy;

namespace Manager
{
	public class BattleFlowManager : MonoBehaviour
	{
		[SerializeField] private AbstractHero hero;
		[SerializeField] private List<AbstractEnemy> enemies;

		private void Init()
		{

		}

		public void OnUpdate()
		{
			
		}
	}
}
