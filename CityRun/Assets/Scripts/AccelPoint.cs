using UnityEngine;
using System.Collections;

public class AccelPoint : MonoBehaviour
{
	public Vector3 add;

	void OnTriggerEnter(Collider other)
	{
		SeManager seManager = SeManager.Instance;

		seManager.SettingPlaySE9();
		other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(add.x, add.y, add.z), ForceMode.Impulse);
	}
}