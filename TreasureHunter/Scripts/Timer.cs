using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

	[SerializeField]
	public static int minute;
	[SerializeField]
	public static float seconds;
	//　前のUpdateの時の秒数
	public static float oldSeconds;
	//　タイマー表示用テキスト
	private Text timerText;

	public static bool count;

	void Start()
	{
	//	minute = 0;
	//	seconds = 0f;
	//	oldSeconds = 0f;
		timerText = GetComponentInChildren<Text>();
		count = false;
	}

	void Update()
	{
	
		if (count == false)
		{
			seconds += Time.deltaTime;
		}
			if (seconds >= 60f)
			{
				minute++;
				seconds = seconds - 60;
			}
			//　値が変わった時だけテキストUIを更新
			if ((int)seconds != (int)oldSeconds)
			{
				timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
			}
			oldSeconds = seconds;
		
	}
}