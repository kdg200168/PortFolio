using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
  //  private ScoreManager scoreManager;


    public void OnClickStartButton()
    {
     //ゲームオーバーになったら数値をリセットする。
        SceneManager.LoadScene("PlayScene");
        ScoreManager.score = 0;
        PlayerHealth.destroyCount = 0;
        PlayerHealth.playerHP = 10;
    }
}
