using UnityEngine;
using System.Collections;

public class DamagingProjectile : DamageClass 
{
	float m_Speed = 7.0f;
	Vector3 m_Destination;
	short m_Range = 10;
	Vector3 m_Direction;

	Vector3 m_SpawnPos;
	// Use this for initialization
	void Start () 
	{
		m_Damage = 0.5f;
		m_SpawnPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float step = m_Speed * Time.deltaTime;

		transform.Translate(m_Direction * step);

		if(Vector3.Distance(transform.position, m_SpawnPos) >= m_Range)
		{
			Destroy(this.gameObject);
		}
	}
	
	public void setUp( Vector3 target)
	{
		m_Direction = Vector3.Normalize(target - transform.position);
	}
	
	void OnCollisionEnter(Collision obj)
	{
		Destroy (this.gameObject);
	}
}
