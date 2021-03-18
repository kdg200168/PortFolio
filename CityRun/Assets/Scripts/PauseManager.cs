using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
	//　ポーズした時に表示するUI
	[SerializeField] private GameObject pauseUI = null;

	[SerializeField] private Button LoadTitleButton = null;
	[SerializeField] private Button resumeButton = null;

	void Start()
    {
		
    }

	// Update is called once per frame
	void Update()
	{
		SeManager seManager = SeManager.Instance;

		if (Input.GetKeyDown(KeyCode.Escape))
			{
				//　ポーズUIのアクティブ、非アクティブを切り替え
				pauseUI.SetActive(!pauseUI.activeSelf);

				//　ポーズUIが表示されてる時は停止
				if (pauseUI.activeSelf)
				{
	
				seManager.SettingPlaySE5();
				Time.timeScale = 0f;
					//　ポーズUIが表示されてなければ通常通り進行
				}
				else
				{
				seManager.SettingPlaySE2();
				Time.timeScale = 1f;
				}
			}
		
	}
 
}

