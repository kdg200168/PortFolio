using UnityEngine;

public class UIManager : MonoBehaviour
{
    // 2つのPanelを格納する変数
    // インスペクターウィンドウからゲームオブジェクトを設定する
    // defaultを入れないと警告が出るので注意
    [SerializeField] GameObject menuPanel = default;
    [SerializeField] GameObject GuidePanel = default;

    void Start()
    {
        // BackToMenuメソッドを呼び出す
        BackToMenu();
    }

    // MenuPanelでGuideButtonが押されたときの処理
    // GuidePanelをアクティブにする
    public void SelectGuideDescription()
    {
        menuPanel.SetActive(false);
        GuidePanel.SetActive(true);
    }

    // 2つのDescriptionPanelでBackButtonが押されたときの処理
    // MenuPanelをアクティブにする
    public void BackToMenu()
    {
        menuPanel.SetActive(true);
        GuidePanel.SetActive(false);
    }
}