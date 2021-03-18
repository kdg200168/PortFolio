using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearTime : MonoBehaviour
{
    [SerializeField]
    public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
       // timerText.text = Timer.minute.ToString("00") + ":" + ((int)Timer.seconds).ToString("00");
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = Timer.minute.ToString("0") + ":" + ((int)Timer.seconds).ToString("0");
    }
}
