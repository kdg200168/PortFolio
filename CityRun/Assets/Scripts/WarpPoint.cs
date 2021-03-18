using UnityEngine;
using System.Collections;

public class WarpPoint : MonoBehaviour
{

	
	public static Vector3 pos;

	void OnTriggerEnter(Collider other)
	{

		SeManager seManager = SeManager.Instance;

		seManager.SettingPlaySE8();
		other.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
	}
}