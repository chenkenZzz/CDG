using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Action;

public class Test : MonoBehaviour
{
	public float time;
	public AbstractAction current = null;

	private void Start()
	{
		current = new MoveCardAction(this.gameObject, Vector3.zero, new Vector3(4, 0, 0), time);
	}
	void Update()
    {

		current.Excute();
    }
}
