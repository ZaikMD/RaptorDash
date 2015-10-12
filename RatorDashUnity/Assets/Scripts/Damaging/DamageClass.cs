using UnityEngine;
using System.Collections;
/// <summary>
/// Damage class. Class that all the things that can cause damage to the player
/// to inherit from.
/// </summary>
public class DamageClass : MonoBehaviour 
{
	protected float m_Damage;

	public float getDamage()
	{
		return m_Damage;
	}
}

