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
//	 [SerializeField]
//	private Text timerText;

	public static float currenttime;

	public   static bool count;
	public static bool change;
	[SerializeField]
	public static int fastminute;
	public static float cleartime;
	public static float fastettime;

	void Start()
	{
		//	minute = 0;
		//	seconds = 0f;
		//	oldSeconds = 0f;
	//	timerText = GetComponentInChildren<Text>();
	//	fasttime = GetComponentInChildren<Text>();
		count = false;
	}

	void Update()
	{
	//	Debug.Log("seconds" + seconds);
		//Debug.Log("minute" + minute);
		//Debug.Log(count);
		// Debug.Log("fasttime" + fastettime);
		// Debug.Log("minute" +fastminute);
		// Debug.Log("clear" + cleartime);
		// Debug.Log("current" + currenttime);
		if (count == false)
		{
			currenttime += Time.deltaTime;
			seconds += Time.deltaTime;
			//seconds = (int)oldSeconds;
		}
		if (seconds >= 60f)
		{
			minute++;
			seconds = seconds - 60;
		}

		//　値が変わった時だけテキストUIを更新
		if ((int)seconds != (int)oldSeconds)
		{
			//timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
		} 
		oldSeconds = seconds;
		if(count == true)
        {
			
			if (currenttime < fastettime)
            {
				fastminute = 0;
				fastettime = currenttime;
				cleartime = Mathf.Floor(fastettime);

				while (cleartime >= 60f  )
				{
					fastminute++;
					cleartime = cleartime - 60;

				}
				 if(fastettime <= 60f)
                {
					fastminute = 0;
				}
			}

		//	timescore = minute + seconds;
        }

	//	timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
		//timerText.text = ((int)currenttime).ToString("00") + "秒";
		//fasttime.text = ((int)fastettime).ToString("00") + "秒";
	}
}