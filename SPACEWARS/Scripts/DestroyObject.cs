using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    // public GameObject effectPrefab;
    // ★★追加
    // 2種類目のエフェクトを入れるための箱
    public GameObject effectPrefab2;
    public int objectHP = 6;
    public static int scoreValue = 100;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;
    public GameObject items;

    // ★追加
    void Start()
    {
        // 「ScoreManagerオブジェクト」に付いている「ScoreManagerスクリプト」の情報を取得して「sm」の箱に入れる。
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            // ★★追加
            // オブジェクトのHPを１ずつ減少させる。
            objectHP -= 1;

            // ★★追加
            // もしもHPが0よりも大きい場合には（条件）
            if (objectHP > 0)
            {
                Destroy(other.gameObject);
                // GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
                //  Destroy(effect, 2.0f);
            }
            else
            { // ★★追加  そうでない場合（HPが0以下になった場合）には（条件）
                Destroy(other.gameObject);

                // もう１種類のエフェクを発生させる。
                GameObject effect2 = Instantiate(effectPrefab2, transform.position, Quaternion.identity);
                Destroy(effect2, 2.0f);

                Destroy(this.gameObject);

                // ★追加
                sm.AddScore(scoreValue);
                if (Random.Range(0, 2) == 0)
                {
                    Instantiate(items, transform.position, transform.rotation);
                }
            }
        }
    }
}