using System;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool
{
	private GameObject prefab;
	private int preCreateNum;
	private List<GameObject> pool;
	
	public GameObjectPool(GameObject prefab,int preCreateNum)
	{
		pool = new List<GameObject>();
		

		this.prefab = prefab;
		this.preCreateNum = preCreateNum;

		for(var i = 0; i < preCreateNum; ++i)
		{
			var go = MonoBehaviour.Instantiate(prefab) as GameObject;
			go.SetActive(false);
			pool.Add(go);
		}
	}

}

