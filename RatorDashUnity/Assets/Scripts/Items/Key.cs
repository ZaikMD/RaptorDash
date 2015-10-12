using UnityEngine;
using System.Collections;
/// <summary>
/// Key class. If the player gets the key then GameInfo will be notified and the key object will be destroyed.
/// </summary>
public class Key : MonoBehaviour 
{
	void OnTriggerEnter(Collider obj)
	{
		if(obj.tag == "Player")
		{
			GameInfo info = (GameInfo)FindObjectOfType(typeof (GameInfo));
			info.setKey(true);

			Destroy(this.gameObject);
		}
	}
}
