using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Card;

public class TestCard : AbstractCard
{
	public override int Cost { get { return 1; } }

	public override bool CanUpgrade => throw new System.NotImplementedException();

	public override bool CanUse => throw new System.NotImplementedException();

	protected override Sprite Illustration { get { return null; } }

	protected override string Name { get { return "Test Card"; } }

	protected override string Description { get { return "Test Description"; } }

	public override AbstractCard Copy()
	{
		throw new System.NotImplementedException();
	}

	public override void OnUpgrade()
	{
		throw new System.NotImplementedException();
	}

	public override void OnUse()
	{
		throw new System.NotImplementedException();
	}

}
