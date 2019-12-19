using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;


namespace FSM
{
	public enum StateType
	{
		CHARA_IDLE,
		CHARA_MOVE,
	}

	public delegate void OnStateEnterCallBack();
	public delegate void OnStateUpdateCallBack();
	public delegate IEnumerator OnStateCoroutinesCallBack();
	public delegate void OnStateEndCallBack();

	public class StateMachine
	{
		private State[] states;
		private int allocPointer = 0;

		private State curState;
		public StateType CurStateType
		{
			get
			{
				return curState.Type;
			}
		}
		private bool isLock = true;

		public StateMachine(int allocSize)
		{
			states = new State[allocSize];
		}

		public void Add(StateType type,
						OnStateEnterCallBack enterCall,
						OnStateUpdateCallBack updateCall,
						OnStateCoroutinesCallBack coroutinesCall,
						OnStateEndCallBack endCall)
		{
			if (allocPointer < states.Length)
			{
				for(var i = 0; i < allocPointer; ++i)
				{
					if(states[i].Type == type)
					{
						Debug.LogWarning("***既に設定した状態");
						return;
					}
				}
				var newStatae = new State(type, enterCall, updateCall, coroutinesCall, endCall);
				states[allocPointer] = newStatae;
				Debug.Log("---" + states[allocPointer].Type.ToString() + "が追加されました");

				allocPointer++;
				if(allocPointer == states.Length)
				{
					Debug.Log("---状態マシン　設定完了");
				}
			}
			else
			{
				Debug.LogWarning("***状態マシン最大状態数の範囲外で、新規状態作成失敗");
			}
		}

		public void Translate(StateType stateType)
		{
			if (stateType == curState.Type)
			{
				Debug.LogWarning("***同じ状態に遷移できない");
			}

			foreach (var state in states)
			{
				if (state.Type == stateType && state != curState)
				{
					curState?.OnEnd();

					Debug.Log("---現在状態は" + curState.Type.ToString() + "から" + state.Type.ToString() + "に変更し" 
						+ curState.OnEnd.Method.ToString() + "が実行された後に" + state.OnEnter.Method.ToString() + "が実行する");

					curState = state;
					curState?.OnEnter();

					//
					if (curState.OnCoroutines != null)
					{
						curState?.OnCoroutines();
						Debug.Log("---Coroutines　：" + curState.OnCoroutines.ToString() + "も実行される");
					}

				}
			}
		}

		public void Lock()
		{
			isLock = true;
			Debug.Log("***状態マシンがロックされた");
		}

		public void UnLock()
		{
			isLock = false;
			Debug.Log("***状態マシンがアンロックされた");
		}

		public void Update()
		{
			if(curState == null)
			{
				Debug.LogWarning("***現在状態はNULLです");
			}
			if(isLock)
			{
				return;
			}

			curState?.OnUpdate();
			Debug.Log("---現在は" + curState.OnUpdate.Method.ToString() + "が実行される");
		}

		public void Start(StateType stateType)
		{
			for(var i = 0; i <allocPointer; ++i)
			{
				if(states[i].Type == stateType)
				{
					curState = states[i];
					Debug.Log("---現在状態初期化成功、これからは" + curState.OnEnter.Method.ToString() + "が実行される");

					curState?.OnEnter();


					if (curState.OnCoroutines != null)
					{
						curState.OnCoroutines();
						Debug.Log("---Coroutines　：" + curState.OnCoroutines.ToString() + "も実行される");
					}
				}
			}
		}
	}
}
