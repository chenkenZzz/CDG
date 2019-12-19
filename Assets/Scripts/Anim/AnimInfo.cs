using System;
using System.Collections.Generic;
using UnityEngine;


namespace Anim
{
	public class AnimInfo
	{
		public List<KeyValuePair<Sprite,bool>> sprites;
		private int spritePreFrame;

		public AnimInfo(string path,int spritePreFrame)
		{
			sprites = new List<KeyValuePair<Sprite, bool>>();

			object[] objects = Resources.LoadAll(path);
			for(var i = 0; i < objects.Length; ++i)
			{
				if (objects[i].GetType().Equals(typeof(Sprite)))
				{
					sprites.Add(new KeyValuePair<Sprite, bool>(objects[i] as Sprite, false));
				}
			}
			this.spritePreFrame = spritePreFrame;
		}

		
		public Sprite GetSprite(int frame)
		{
			frame = frame % (sprites.Count * spritePreFrame);
			var num = (frame - 1) / spritePreFrame;
			if (num < 0) num = 0;
			return sprites[num].Key;
		}
	}
}

