using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class Actor : MonoBehaviour
{
	private StateMachine stateMachine;

	public void Awake()
	{
		stateMachine = new StateMachine(2);
		stateMachine.Add(StateType.CHARA_IDLE, OnIdleEnter, OnIdleUpdate, null, OnIdleEnd);
		stateMachine.Add(StateType.CHARA_MOVE, OnMoveEnter, OnMoveUpdate, null, OnMoveEnd);
		stateMachine.Start(StateType.CHARA_IDLE);
		stateMachine.UnLock();
	}

	public void Update()
	{
		stateMachine.Update();
	}

	#region Character Idle
	private void OnIdleEnter()
	{
		Debug.Log("Test : 待機状態に入る");
	}

	private void OnIdleUpdate()
	{
		Debug.Log("Test : 待機状態更新");
		if(Input.GetKeyDown(KeyCode.Space))
		{
			stateMachine.Translate(StateType.CHARA_MOVE);
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
		}
	}

	private void OnMoveEnd()
	{
		Debug.Log("Test : 移動状態終わり");
	}

	#endregion
}
