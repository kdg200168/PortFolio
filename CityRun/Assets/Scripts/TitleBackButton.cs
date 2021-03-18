using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleBackButton : MonoBehaviour
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
        // ShowWindow();
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
        seManager.SettingPlaySE2();
        transform.DOKill();
        //transform.DOShakeScale(1f);
        transform.DOScale(0.1f, 1f)
               .SetRelative(true)
               .SetEase(Ease.OutQuart)
               .SetLoops(1, LoopType.Restart)
               .SetLink(gameObject);

        transform.localScale = defaultScale;
        //  TitlePanel.SetActive(true);
        //  OperationPanel.SetActive(false);
        Invoke("ShowWindow", 1);
        Invoke("Scale", 1);
        Invoke("SetActive", 2);
        Invoke("Buttonflag", 3f);
    }
    void ShowWindow()
    {
        SeManager seManager = SeManager.Instance;
        seManager.SettingPlaySE4();
        // transform.localScale = Vector3.zero;
        OperationPanel.transform.DOScale(0.001f, 1f).SetEase(Ease.InBounce);
        // OperationPanel.SetActive(false);
        //TitlePanel.SetActive(true);
    }
    void Scale()
    {
         transform.DOScale(1.0f, 2f);
    }
    void SetActive()
    {
        TitlePanel.SetActive(true);
        OperationPanel.SetActive(false);
    }
    void Buttonflag()
    {
        GetComponent<Button>().interactable = true;
    }
}