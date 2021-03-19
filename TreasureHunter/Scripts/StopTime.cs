using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopTime : MonoBehaviour
{
    private Timer timer;
    //　タイマー表示用テキスト
    private Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
        timerText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer.count = true;
        timerText.text = Timer.minute.ToString("00") + ":" + ((int)Timer.seconds).ToString("00");
    }
}
