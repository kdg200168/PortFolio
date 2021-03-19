using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPlayScene : MonoBehaviour
{
    public void OnClickStartButton()
    {
        // ゲームオーバーになったら数値をリセットする。
        SceneManager.LoadScene("PlayScene");

      //  PlayerHP.playerhp = 10;
        TimeLimit.time = 300f;
        Timer.minute = 0;
        Timer.seconds = 0f;
        Timer.oldSeconds = 0f;
    }   
}
