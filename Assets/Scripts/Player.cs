using System;
using System.Collections.Generic;
using UnityEngine;
using FSM;
using Anim;

public class Player : Actor
{
	private StateMachine stateMachine;
	public AnimMachine animMachine;

	private SpriteRenderer spriteRenderer;
	private new void Awake()
	{
		base.Awake();

		spriteRenderer = GetComponent<SpriteRenderer>();

	    stateMachine = new StateMachine(2);
		stateMachine.Add(StateType.CHARA_IDLE, OnIdleEnter, OnIdleUpdate, null, OnIdleEnd);
		stateMachine.Add(StateType.CHARA_MOVE, OnMoveEnter, OnMoveUpdate, null, OnMoveEnd);
		stateMachine.Start(StateType.CHARA_IDLE);
		stateMachine.UnLock();

		animMachine = new AnimMachine();
		animMachine.Add(StateType.CHARA_IDLE, new AnimInfo("Player/Idle", 10));
		animMachine.Add(StateType.CHARA_MOVE, new AnimInfo("Player/Move", 10));
		animMachine.Unlock();
	}

	private new void Update()
	{
		stateMachine.Update();
		animMachine.Update(stateMachine.CurStateType, spriteRenderer);
	}

	#region Character Idle
	private void OnIdleEnter()
	{
		Debug.Log("Test : 待機状態に入る");
	}

	private void OnIdleUpdate()
	{
		Debug.Log("Test : 待機状態更新");
		if (Input.GetKeyDown(KeyCode.Space))
		{
			stateMachine.Translate(StateType.CHARA_MOVE);
			animMachine.ResetAnim();
		}
	}

	private void OnIdleEnd()
	{
		Debug.Log("Test : 待機状態終わり");
	}
	#endregion

	#region Character move
	private void OnMoveEnter()
	{
		Debug.Log("Test : 移動状態に入る");
	}

	private void OnMoveUpdate()
	{
		Debug.Log("Test : 移動状態更新");
		if (Input.GetKeyDown(KeyCode.Space))
		{
			stateMachine.Translate(StateType.CHARA_IDLE);
			animMachine.ResetAnim();
		}
	}

	private void OnMoveEnd()
	{
		Debug.Log("Test : 移動状態終わり");
	}

	#endregion
}

