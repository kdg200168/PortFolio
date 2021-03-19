using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShotShell : MonoBehaviour
{
    public GameObject enemyShellPrefab;
    public float shotSpeed;
    //  public AudioClip shotSound;
    private int shotIntarval;
    private Vector3 PEnemy_pos;
    public Transform target;
    public float speed = 2F;

    private void OnTriggerStay(Collider other)
    {
        shotIntarval += 1;
        // もしも他のオブジェクトに「Player」というTag（タグ）が付いていたならば（条件）
        if (other.CompareTag("Player"))
        {
            // 「root」を使うと「親（最上位の親）」の情報を取得することができる（ポイント）
            // LookAt()メソッドは指定した方向にオブジェクトの向きを回転させることができる（ポイント）
            transform.LookAt(target);
            // Debug.Log("Look");
        }
        if (shotIntarval % 5000 == 0)
        {
            GameObject enemyShell = Instantiate(enemyShellPrefab, new Vector3(transform.position.x, transform.position.y + 5, transform.position.z), this.transform.rotation);

            Rigidbody enemyShellRb = enemyShell.GetComponent<Rigidbody>();

            // forwardはZ軸方向（青軸方向）・・・＞この方向に力を加える。
            enemyShellRb.AddForce(transform.forward * shotSpeed);

            // AudioSource.PlayClipAtPoint(shotSound, transform.position);

            Destroy(enemyShell, 5.0f);
        }
    }
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }
}