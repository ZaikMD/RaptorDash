using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour 
{
	public Vector3 m_Direction;
	float m_Speed = 6.0f;
	float m_MaxDist = 5.0f;
	Vector3 m_InitialPosition;
	// Use this for initialization
	void Start () 
	{
		m_InitialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Vector3.Distance(m_InitialPosition, transform.position ) > m_MaxDist)
		{
			Destroy(this.gameObject);
		}

		transform.Translate (m_Direction * m_Speed * Time.deltaTime);
	}
}
