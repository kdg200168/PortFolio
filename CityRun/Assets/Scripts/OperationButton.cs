using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class OperationButton : MonoBehaviour
{
    [SerializeField] GameObject TitlePanel = null;
    [SerializeField] GameObject OperationPanel = null;
    Vector3 defaultScale;
    // Start is called before the first frame update
    void Awake()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        OperationPanel.transform.localScale = Vector3.zero;
       
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
        seManager.SettingPlaySE1();

        transform.DOKill(); 
     
        transform.DOScale(0.1f, 1f)
               .SetRelative(true)
               .SetEase(Ease.OutQuart)
               .SetLoops(1, LoopType.Restart)
               .SetLink(gameObject);
        transform.localScale = defaultScale;
       
     
        Invoke("ShowWindow",1);
        Invoke("Buttonflag", 1f);
        Invoke("Scale", 1);
        Invoke("SetActive", 1);
    }
    void ShowWindow()
    {
        SeManager seManager = SeManager.Instance;
        seManager.SettingPlaySE3();
        OperationPanel.transform.DOScale(1f, 1f).SetEase(Ease.OutBounce);
    }
    void Scale()
    {
         transform.DOScale(1.0f, 2f);
    }
    void SetActive()
    {
        OperationPanel.SetActive(true);
        TitlePanel.SetActive(false);
    }
    void Buttonflag()
    {
        GetComponent<Button>().interactable = true;
    }
}
