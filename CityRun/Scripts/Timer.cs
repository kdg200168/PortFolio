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
	public static float fastettime =300f;

	void Start()
	{

		count = false;
	}

	void Update()
	{
	
		//
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
	/*	if ((int)seconds != (int)oldSeconds)
		{
			//timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
		} */
		oldSeconds = seconds;
		//時間測定が止まったら
		if(count == true)
        {
			// ハイスコアの計算
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


        }


	}
}