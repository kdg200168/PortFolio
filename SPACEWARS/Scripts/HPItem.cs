using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPItem : MonoBehaviour
{
    public GameObject effectPrefab;
    public AudioClip getSound;
    private PlayerHealth ph;
    private int reward = 4; // いくつ回復させるかは自由！

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Find()メソッドの使い方をマスターすること
            ph = GameObject.Find("Player").GetComponent<PlayerHealth>();

            // AddHP()メソッドを呼び出して「引数」にrewardを与えている。
            ph.AddHP(reward);

            Destroy(gameObject);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            AudioSource.PlayClipAtPoint(getSound, Camera.main.transform.position);
        }
    }
}