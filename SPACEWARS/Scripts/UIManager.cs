using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //３つのPanelを格納する変数
    //インスペクターウィンドウからゲームオブジェクトを設定する
    [SerializeField] GameObject menuPanel = default;
    [SerializeField] GameObject GuidePanel = default;

    // Start is called before the first frame update
    void Start()
    {
        //BackToMenuメソッドを呼び出す
        BackToMenu();
    }


    //MenuPanelでXR-HubButtonが押されたときの処理
    //XR-HubPanelをアクティブにする
    public void SelectGuideDescription()
    {
        menuPanel.SetActive(false);
        GuidePanel.SetActive(true);
    }

    //2つのDescriptionPanelでBackButtonが押されたときの処理
    //MenuPanelをアクティブにする
    public void BackToMenu()
    {
        menuPanel.SetActive(true);
        GuidePanel.SetActive(false);
    }
}