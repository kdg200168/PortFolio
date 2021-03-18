using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class QuitApp : MonoBehaviour
{
    public AudioSource audioSource;
    Vector3 defaultScale;
    // Start is called before the first frame update
    void Awake()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);

    }
    // Start is called before the first frame update
    void Start()
    {
        defaultScale = transform.localScale;

    }

    // Update is called once per frame
    public void OnClick()
    {
        GetComponent<Button>().interactable = false;
        SeManager seManager = SeManager.Instance;
        seManager.SettingPlaySE1();

        transform.DOKill();
    
        transform.DOScale(0.1f, 1f)
               .SetRelative(true)
               .SetEase(Ease.OutQuart)
               .SetLoops(1, LoopType.Restart)
               .SetLink(gameObject)
                .Kill();
        transform.localScale = defaultScale;
        Invoke("Buttonflag", 1f);
        Invoke("Scale", 1);
        Application.Quit();
    }
    void Scale()
    {
        transform.DOScale(1.0f, 2f);
    }
    void Quitapp()
    {
        Application.Quit();
    }
    void Buttonflag()
    {
        GetComponent<Button>().interactable = true;
    }
}
