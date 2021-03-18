using UnityEngine;
using UnityEngine.UI;

public class Pausemenu : MonoBehaviour
{
 //   [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject pausePanel = null;
    [SerializeField] private Button resumeButton = null; 
    [SerializeField] private Button LoadTitleButton = null;

    void Start()
    {
       Button button = GetComponent<Button>();
        pausePanel.SetActive(false);
      //  pauseButton.onClick.AddListener(Pause);
        LoadTitleButton.onClick.AddListener(LoadTitle);
        resumeButton.onClick.AddListener(Resume);
    }

    public  void Pause()
    {
     //   GetComponent<Button>().interactable = false;
        SeManager seManager = SeManager.Instance;
        seManager.SettingPlaySE1();
        Debug.Log("test");
            Time.timeScale = 0;  // 時間停止
            pausePanel.SetActive(true);
      //  Invoke("Buttonflag", 1f);

    }

    public void Resume()
    {
      // GetComponent<Button>().interactable = false;
        SeManager seManager = SeManager.Instance;
        seManager.SettingPlaySE2();
        Time.timeScale = 1;  // 再開
        pausePanel.SetActive(false);
      //  Invoke("Buttonflag", 1f);
    }
    public void LoadTitle()
    {
     //  GetComponent<Button>().interactable = false;
        Time.timeScale = 1;  // 再開
        SeManager seManager = SeManager.Instance;
        seManager.SettingPlaySE7();
      //  Invoke("Buttonflag", 1f);
        FadeManager.Instance.LoadScene("TitleScene", 1f);
    }
   // void Buttonflag()
  //  {
  //      GetComponent<Button>().interactable = true;
  //  }
}