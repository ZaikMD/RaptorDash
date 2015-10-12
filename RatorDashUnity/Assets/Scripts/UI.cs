using UnityEngine;
using System.Collections;
/// <summary>
/// UI: Will control the ui for the game. Eg: Health, lives, etc.
/// </summary>
public class UI : MonoBehaviour 
{

	GameObject m_HealthTextObj;
	GUIText m_HealthText;

	GameObject m_LivesTextObj;
	GUIText m_LivesText;

	PlayerHealth m_PHealth;

	GameInfo m_Info;

	void Awake ()
	{
		m_HealthTextObj = GameObject.Find ("HealthText");
		
		m_HealthText = m_HealthTextObj.GetComponent (typeof(GUIText)) as GUIText;

		m_PHealth = FindObjectOfType (typeof(PlayerHealth)) as PlayerHealth;

		m_LivesTextObj = GameObject.Find ("LivesText");
		
		m_LivesText = m_LivesTextObj.GetComponent (typeof(GUIText)) as GUIText;

		m_Info = FindObjectOfType (typeof(GameInfo)) as GameInfo;
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_HealthText.text = "Health: " + m_PHealth.getHealth (); // Display player health on the ui
		m_Info.setHealth (m_PHealth.getHealth ()); //Set player health in gameInfo

		m_LivesText.text = "Lives: " + m_PHealth.getLives (); //Display lives
		m_Info.setLives (m_PHealth.getLives ()); //Set lives in gameInfo
	}

}
