using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
	private GameObject root;

	private UI_TalkTextHandler textHandler;
	private GameObject talkPrefab;

	public override void Initialize()
	{
		root = GameObject.Find("Canvas") as GameObject;

		talkPrefab = Resources.Load("talkBubblePrefab") as GameObject;
		textHandler = new UI_TalkTextHandler(root, talkPrefab);

		MsgCenter.Instance.Subscribe(MsgType.MSG_TALK_TO_NPC, MsgHandle);
	}

	private void MsgHandle(Msg msg)
	{
		switch(msg.Type)
		{
			case MsgType.MSG_TALK_TO_NPC:
				var NPC = msg["NPC"] as AbstractNPC;
				textHandler.SetTalk(NPC.Name,NPC.TalkData, NPC.transform.position);
				break;
		}
	}

	public void Execute()
	{
		textHandler.Execute();
	}

	public override void Destory()
	{
		MsgCenter.Instance.Unsubscribe(MsgType.MSG_TALK_TO_NPC, MsgHandle);
	}

}
