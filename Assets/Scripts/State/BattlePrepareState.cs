using System;
using System.Collections.Generic;
using UnityEngine;
using Manager;

namespace State
{
	public class BattlePrepareState : AbstractState
	{
		private Animator animator;
		public override StateType Type
		{
			get
			{
				return StateType.BATTLE_PREPARE;
			}
		}

		public BattlePrepareState(Animator animator)
		{
			this.animator = animator;
		}

		public override void OnEnter()
		{
			animator.Play("BattlePrepare");
			MsgManager.Instance.Fire(new Msg.Msg(MsgType.MSG_BATTLE_START_ANIMATION_PLAY));
		}

		public override void OnExit()
		{
			MsgManager.Instance.Fire(new Msg.Msg(MsgType.MSG_BATTLE_START_ANIMATION_OVER));
		}
	}
}
