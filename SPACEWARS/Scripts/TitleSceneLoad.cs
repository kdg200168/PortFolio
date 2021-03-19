using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneLoad : MonoBehaviour
{
   // private ScoreManager scoreManager;


        public void OnClickStartButton()
    {
    
    //    scoreManager.Reset_score();  // ★追加（ゲームオーバーになったらスコアをリセットする。）
        SceneManager.LoadScene("TitleScene");
        ScoreManager.score = 0;
        PlayerHealth.destroyCount = 0;
        PlayerHealth.playerHP = 10;
    }
}

