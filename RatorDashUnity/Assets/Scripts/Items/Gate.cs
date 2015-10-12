using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour 
{

	public int m_Level;

	GameInfo m_Info;
	void Awake()
	{
		m_Info = FindObjectOfType (typeof(GameInfo)) as GameInfo;
		m_Info.setLevel (m_Level);
	}

	void OnTriggerEnter(Collider obj)
	{
		if(obj.tag == "Player")
		{
			GameInfo info = (GameInfo)FindObjectOfType(typeof (GameInfo));
			LoadLevel load = (LoadLevel)FindObjectOfType(typeof (LoadLevel));

			if(info.getKey())
			{
				info.setKey(false);
				Application.LoadLevel("Level" + (m_Level + 1));
			}
		}


	}
}
