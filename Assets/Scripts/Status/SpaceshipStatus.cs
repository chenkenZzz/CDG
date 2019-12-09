using System;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipStatus
{
	public string name;
	public int hp;
	public int hpMax;
	public float spd;
	public float atk;
	public float def;

	private int resetHp;
	private int resetHpMax;
	private float resetSpd;
	private float resetAtk;
	private float resetDef;

	public SpaceshipStatus(SpaceshipStatus spaceshipStatus)
	{
		this.name = spaceshipStatus.name;
		this.hp = spaceshipStatus.hp;
		this.hpMax = spaceshipStatus.hpMax;
		this.spd = spaceshipStatus.spd;
		this.atk = spaceshipStatus.atk;
		this.def = spaceshipStatus.def;

		resetHp = hp;
		resetHpMax = hpMax;
		resetSpd = spd;
		resetAtk = atk;
		resetDef = def;
	}

	public void Reset()
	{
		hp = resetHp;
		hpMax = resetHpMax;
		spd = resetSpd;
		atk = resetAtk;
		def = resetDef;
	}
}

