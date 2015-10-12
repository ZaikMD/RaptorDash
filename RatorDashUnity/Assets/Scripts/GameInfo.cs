using UnityEngine;
using System.Collections;
/// <summary>
/// Game info:  Handles all the Info that will need to be saved between levels; Lives, health, score, etc.
/// </summary>
/// 
public class GameInfo : MonoBehaviour 
{




	short m_Lives = 3;
	float m_Health = 3.0f;
	int m_Score;
	bool m_Key = false;
	int m_CurrentLevel = 1;

	UI m_UI;


	void Awake() //Game Data should not be destroyed at all.
	{
		Object.DontDestroyOnLoad (this.gameObject);
	}

	
	public void setHealth(float health)
	{
		m_Health = health;
	}

	public float getHealth()
	{
		return m_Health;
	}

	public void setLives(short lives)
	{
		m_Lives = lives;
	}

	public short getLives()
	{
		return m_Lives;
	}

	public void setScore(int score)
	{
		m_Score = score;
	}

	public void setKey(bool key)
	{
		m_Key = key;
	}

	public bool getKey()
	{
		return m_Key;
	}

	public void setLevel(int level)
	{
		m_CurrentLevel = level;
	}
}
