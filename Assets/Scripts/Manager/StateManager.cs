using System;
using System.Collections.Generic;
using State;

namespace Manager
{
	public class StateManager
	{
		private Dictionary<StateType, AbstractState> states;
		private AbstractState current;
		public AbstractState Current
		{
			get
			{
				return current;
			}
		}

		public StateManager()
		{
			states = new Dictionary<StateType, AbstractState>();
		}

		public void Add(AbstractState state)
		{
			if(state == null)
			{
				//DEBUG LOG

				return;
			}

			if(states.ContainsKey(state.Type))
			{
				//DEBUG LOG

				return;
			}
			states.Add(state.Type, state);
		}

		public void Clear()
		{
			states.Clear();
		}

		public void Start(StateType type)
		{
			if(!states.ContainsKey(type))
			{
				//DEBUG LOG

				return;
			}
			current = states[type];
			current.OnEnter();
		}

		public void OnUpdate()
		{
			if (current != null)
			{
				current.OnUpdate();
			}
		}

		public void Translate(StateType type)
		{
			if(!states.ContainsKey(type))
			{
				//DEBUG LOG

				return;
			}
			if(current == null)
			{
				//DEBUG LOG 

				return;
			}
			current.OnExit();
			current = states[type];
			current.OnEnter();
		}
	}
}
