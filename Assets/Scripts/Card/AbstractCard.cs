using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCard : MonoBehaviour
{
	protected Status cardStatus = new Status();
	public abstract void Init();
	public virtual void OnDraw() { }
	public virtual void OnDiscard() { }
	public virtual void OnUpgrade() { }
	public virtual void OnUse() { }

}
