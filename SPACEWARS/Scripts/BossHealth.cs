using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    // public GameObject effectPrefab;
    // ★★追加
    // 2種類目のエフェクトを入れるための箱
    public GameObject effectPrefab2;
    public int BossHP = 200;
    public static int scoreValue = 5000;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;

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
            BossHP -= 1;
         
            // ★★追加
            // もしもHPが0よりも大きい場合には（条件）
            if (BossHP > 0)
            {
                Destroy(other.gameObject);
                // GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
                //  Destroy(effect, 2.0f);
              //  Debug.Log("hit");
            }
            else
            { // ★★追加  そうでない場合（HPが0以下になった場合）には（条件）
                Destroy(other.gameObject);

                // もう１種類のエフェクを発生させる。
                GameObject effect2 = Instantiate(effectPrefab2, transform.position, Quaternion.identity);
                Destroy(effect2, 2.0f);

                this.gameObject.SetActive(false);
                Invoke("GoToGameClear", 3.0f);
                // ★追加
                sm.AddScore(scoreValue);
            }
        }
    }
    void GoToGameClear()
    {
        SceneManager.LoadScene("GameClearScene");
    }
}