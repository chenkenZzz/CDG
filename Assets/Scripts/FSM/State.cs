using System;
using System.Collections.Generic;


namespace FSM
{
	public class State
	{
		public StateType Type { private set; get; }
		public OnStateEnterCallBack OnEnter { private set; get; }
		public OnStateUpdateCallBack OnUpdate { private set; get; }
		public OnStateCoroutinesCallBack OnCoroutines { private set; get; }
		public OnStateEndCallBack OnEnd { private set; get; }

		public State(StateType type,OnStateEnterCallBack enterCall,OnStateUpdateCallBack updateCall,OnStateCoroutinesCallBack coroutinesCall, OnStateEndCallBack endCall)
		{
			Type = type;

			this.OnEnter = enterCall;
			this.OnUpdate = updateCall;
			this.OnCoroutines = coroutinesCall;
			this.OnEnd = endCall;
		}
	}
}
