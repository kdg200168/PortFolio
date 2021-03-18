using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopTime : MonoBehaviour
{
    private Timer timer;

    //　タイマー表示用テキスト
    [SerializeField]
    public Text timerText;
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
        timerText.text =  Timer.minute.ToString("0") + ":" + ((int)Timer.seconds).ToString("0");
    }
}
