using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTitleScene : MonoBehaviour
{
    public void OnClickStartButton()
    {
        // 画面遷移をする際に数値をリセットする
        SceneManager.LoadScene("TitleScene");
       // PlayerHP.playerhp = 10;
       // TimeLimit.time = 300f;
    }
}