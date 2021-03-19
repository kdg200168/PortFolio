using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ★追加
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private AudioSource sound01;

    public GameObject effectPrefab;
    public GameObject effectPrefab2;
    public static int playerHP = 10;
    private Slider hpSlider;
    public GameObject[] playerIcons;
    public static int destroyCount = 0;
    public bool isMuteki = false;
    // ★追加
    private ScoreManager scoreManager;


    private void Start()
    {
        sound01 = GetComponent<AudioSource>();
        scoreManager = GameObject.Find("ScoreLabel").GetComponent<ScoreManager>();
        hpSlider = GameObject.Find("PlayerHPSlider").GetComponent<Slider>();
        hpSlider.maxValue = playerHP;
        hpSlider.value = playerHP;
        UpdatePlayerIcons();
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("EnemyBullet") && isMuteki == false)
        {
            playerHP -= 1;
            sound01.PlayOneShot(sound01.clip);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(effect, 1.0f);
            hpSlider.value = playerHP;

            if (playerHP == 0)
            {
                destroyCount += 1;
                UpdatePlayerIcons();
                GameObject effect2 = Instantiate(effectPrefab2, transform.position, Quaternion.identity);
                Destroy(effect2, 1.0f);

                // プレーヤーを破壊するのではなく、非アクティブ状態にする
                this.gameObject.SetActive(false);
                // ★追加
                if (destroyCount < 3) 
                {
                    // リトライ
                    Invoke("Retry", 2.0f);
                }
                else
                {
                    // ゲームオーバー
                    Invoke("GoToGameOver", 5.0f);

                    // destroyCountをリセット
                    destroyCount = 0;
                }
            }
        }
    }
    void GoToGameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }
    void UpdatePlayerIcons()
    {
        for (int i = 0; i < playerIcons.Length; i++)
        {
            if (destroyCount <= i)
            {
                playerIcons[i].SetActive(true);
            }
            else
            {
                playerIcons[i].SetActive(false);
            }
        }
    }

    void Retry()
    {
        this.gameObject.SetActive(true);
        playerHP = 10;
        hpSlider.value = playerHP;
        isMuteki = true;
        Invoke("MutekiOff", 2.0f);
    }

    void MutekiOff()
    {
        isMuteki = false;
    }

    public void AddHP(int amount)
    {
        playerHP += amount;

        if (playerHP > 10)
        {
            playerHP = 10;
        }

        hpSlider.value = playerHP;
    }

}