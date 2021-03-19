using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApp : MonoBehaviour
{
    //　ボタンを押すとアプリケーション終了
    public void OnClickEndButton()
    {
        Application.Quit();
    }
}
