using System;
using System.Collections.Generic;

public abstract class Singleton<T> where T : class,new()
{
	private static T instance;
	public static T Instance
	{
		get
		{
			if (instance == null)
				instance = new T();
			return instance;
		}
	}

	public abstract void Init();
	public void Destory()
	{
		instance = null;
	}
}

