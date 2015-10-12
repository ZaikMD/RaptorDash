using UnityEngine;
using System.Collections;

public class ProjectileSpawn : MonoBehaviour
{
	public GameObject m_Projectile;
	public SphereCollider m_AreaRange;

	float m_SphereRange;
	float m_FireRate = 0.25f;
	float m_ConstFireRate;

	bool m_HasFired = false;

	void Start()
	{
		m_ConstFireRate = m_FireRate;
		m_SphereRange = m_AreaRange.radius * 2;
	}

	// Update is called once per frame
	void Update () 
	{
		if(m_HasFired)
		{
			m_FireRate -= Time.deltaTime;
		}

		if(m_FireRate <= 0.0f)
		{
			m_HasFired = false;
			m_FireRate = m_ConstFireRate;
		}
	}

	void fireProjectile(Vector3 pos)
	{
		GameObject proj = (GameObject)Instantiate(m_Projectile, transform.position, Quaternion.identity);

		DamagingProjectile damProj = proj.GetComponent(typeof(DamagingProjectile)) as DamagingProjectile;

		damProj.setUp(pos);
	}

	void OnTriggerStay(Collider obj)
	{
		if(obj.tag == "Player")
		{
			Vector3 direction = Vector3.Normalize(obj.transform.position - transform.position);
			RaycastHit hitinfo;
			Physics.Raycast(transform.position,direction, out hitinfo, m_SphereRange);

			if(m_HasFired == false && hitinfo.transform.tag == "Player")
			{
				fireProjectile(obj.transform.position);
				m_HasFired = true;
			}
		}
	}
}
