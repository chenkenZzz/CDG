using System;
using System.Collections.Generic;
using UnityEngine;


namespace Manager
{
	[DefaultExecutionOrder(-100)]
	[DisallowMultipleComponent]
	public class GameManager : MonoBehaviour
	{
		private void Awake()
		{
			MsgManager.Instance.Init();
			RandomManager.Instance.Init();
			ActionManager.Instance.Init();
		}

		private void Start()
		{
			
		}

		private void Update()
		{
			
		}

		private void OnDestroy()
		{
			MsgManager.Instance.Destory();
			RandomManager.Instance.Destory();
			ActionManager.Instance.Destory();
		}
	}
}
