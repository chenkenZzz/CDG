using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
	public class VirtualPlayerManager : MonoBehaviour
	{
		private Status status = new Status();
		public Status Status
		{
			get
			{
				return status;
			}
		}

		private void Init()
		{

		}

	}
}
