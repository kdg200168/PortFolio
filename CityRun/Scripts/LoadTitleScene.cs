using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LoadTitleScene : MonoBehaviour
{

    Vector3 defaultScale;
    // Start is called before the first frame update
    void Awake()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }
    void Start()
    {
        defaultScale = transform.localScale;
    }

    // Update is called once per frame
    void OnClick()
    {
        GetComponent<Button>().interactable = false;
        SeManager seManager = SeManager.Instance;
        seManager.SettingPlaySE7();

        transform.DOKill();

        transform.DOScale(0.1f, 1f)
               .SetRelative(true)
               .SetEase(Ease.OutQuart)
               .SetLoops(1, LoopType.Restart)
               .SetLink(gameObject);
        transform.localScale = defaultScale;
        Invoke("Buttonflag", 1f);
        Invoke("Scale", 1);
        FadeManager.Instance.LoadScene("TitleScene", 1f);

        TimeLimit.totalTime = 300f;
        //Timer.minute = 0;
       // Timer.seconds = 0f;
       // Timer.oldSeconds = 0f;
    }
   
    void Scale()
    {

        transform.DOScale(1.0f, 2f);
    }
    void Buttonflag()
    {
        GetComponent<Button>().interactable = true;
    }

}
 