using System;
using System.Collections.Generic;
using UnityEngine;

namespace Anim
{
	[Serializable]
	public class AnimMachine
	{
		public Dictionary<FSM.StateType, AnimInfo> anims;
		[SerializeField] private int curAnimFrame = 0;
		[SerializeField] private bool isLock = true;

		public AnimMachine()
		{
			anims = new Dictionary<FSM.StateType, AnimInfo>();
		}

		public void Update(FSM.StateType stateType, SpriteRenderer spriteRenderer)
		{
			if (isLock)
				return;

			spriteRenderer.sprite = anims[stateType].GetSprite(curAnimFrame++);
		}

		public void ResetAnim()
		{
			curAnimFrame = 0;
		}

		public void Add(FSM.StateType stateType, AnimInfo animInfo)
		{
			if(anims.ContainsKey(stateType))
			{
				Debug.LogWarning("***" + stateType.ToString() + "のアニメーションは既に存在する");
				return;
			}

			if(animInfo == null)
			{
				Debug.LogWarning("***アニメーションはNULL");
				return;
			}
			anims.Add(stateType, animInfo);
		}

		public void Lock()
		{
			isLock = true;
		}

		public void Unlock()
		{
			isLock = false;
		}
	}
}

