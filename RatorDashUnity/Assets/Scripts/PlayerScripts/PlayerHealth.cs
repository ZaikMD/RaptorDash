using UnityEngine;
using System.Collections;
/// <summary>
/// Player health :  Manages the players health and respawns them if they die.
/// </summary>
public class PlayerHealth : MonoBehaviour 
{


	float m_Health;
	float m_MaxHealth = 3.0f;

	Vector3 m_RespawnPoint;

	float m_ImmuneTimer = 0.75f;
	float m_ConstImmuneTimer;
	bool m_Damaged = false;

	short m_Lives;

	GameInfo m_Info;
	
	// Use this for initialization
	void Awake () 
	{
		m_RespawnPoint = transform.position;
		m_ConstImmuneTimer = m_ImmuneTimer;

		m_Info = FindObjectOfType (typeof (GameInfo)) as GameInfo;

		m_Health = m_Info.getHealth ();
		m_Lives = m_Info.getLives ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(m_Health <= 0.0f)
		{
			transform.position = m_RespawnPoint;
			m_Health = m_MaxHealth;

			m_Lives -= 1;
		}

		if(m_Damaged)
		{
			m_ImmuneTimer -= Time.deltaTime;
		}

		if(m_ImmuneTimer <= 0.0f)
		{
			m_ImmuneTimer = m_ConstImmuneTimer;
			m_Damaged = false;
		}
	}

	void OnTriggerEnter(Collider obj)
	{
		if(obj.gameObject.tag == "Damaging" && !m_Damaged)
		{
			DamageClass dmg = obj.gameObject.GetComponent(typeof(DamageClass)) as DamageClass;

			m_Health -= dmg.getDamage();
			m_Damaged = true;
		}
	}

	void OnTriggerStay(Collider obj)
	{
		if(obj.gameObject.tag == "Spikes")
		{
			if(!m_Damaged)
			{
				DamageClass dmg = obj.gameObject.GetComponent(typeof(DamageClass)) as DamageClass;
			
				m_Health -= dmg.getDamage();
				m_Damaged = true;
			}
		}
	}

	public float getHealth()
	{
		return m_Health;
	}

	public short getLives()
	{
		return m_Lives;
	}
}
