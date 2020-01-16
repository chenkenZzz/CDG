using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TalkTextHandler
{
	private const float readTextMaxTime = 0.1f;
	private const float lockCoolDownMaxTime = 0.5f;

	private GameObject root;
	private GameObject talkBubblePrefab;
	private Image talkUIImage;
	private Text talkUIText;
	private string[] talkData;

	private bool isLock = false;
	private bool isTalkStart = false;
	private bool isOver = true;

	private int index = 0;
	private int lineIndex = 0;
	private float readPerCharTimer = 0;

	private bool isLockCoolDown = false;
	private float lockCoolDownTimer;

    public UI_TalkTextHandler(GameObject root, GameObject prefab)
	{
		this.root = root;
		talkBubblePrefab = prefab;
	}

	public void Execute()
	{
		if(isTalkStart)
		{
			readPerCharTimer += Time.deltaTime;

			if (readPerCharTimer >= readTextMaxTime)
			{
				if (lineIndex < talkData[index].Length)
				{
					talkUIText.text += talkData[index][lineIndex];
					lineIndex++;
					readPerCharTimer = 0f;
				}
				else
				{
					if (index < talkData.Length - 1)
					{
						if (Input.GetKeyDown(KeyCode.Space))
						{
							lineIndex = 0;
							index++;
							talkUIText.text = "";

							readPerCharTimer = 0f;
						}
					}
					else
					{
						if (Input.GetKeyDown(KeyCode.Space))
						{
							MonoBehaviour.Destroy(talkUIImage.gameObject);
							isTalkStart = false;
							isLockCoolDown = true;
							isOver = true;
							readPerCharTimer = 0f;
							lineIndex = 0;
							index = 0;
						}
					}
				}
			}
		}

		if(isLockCoolDown)
		{
			lockCoolDownTimer += Time.deltaTime;
			if(lockCoolDownTimer >= lockCoolDownMaxTime)
			{
				isLock = false;
				isLockCoolDown = false;
				lockCoolDownTimer = 0f;
			}
		}
	}

	public void SetTalk(string npcName,string[] talkData,Vector3 pos)
	{
		if (isLock)
			return;

		this.talkData = talkData;
		isTalkStart = true;
		isLock = true;
		isOver = false;

		var talk =  MonoBehaviour.Instantiate(talkBubblePrefab,Vector3.zero, Quaternion.identity);
		talk.transform.parent = root.transform;
		talk.transform.position = Camera.main.WorldToScreenPoint(pos);

		talkUIImage = talk.GetComponent<Image>();
		talkUIText = talk.transform.GetChild(0).GetComponent<Text>();
		talkUIText.text = "";

		talk.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = npcName;

		Debug.Log(talk.transform.position);
	}
		
}
