using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ChangeFade : MonoBehaviour
{
  //  QuitApp quitapp;
    public Ease EaseType; //イージングタイプ指定
    public  bool fadeoutflag;
  
    void Start()
    {
        DG.Tweening.DOTween.SetTweensCapacity(tweenersCapacity: 500, sequencesCapacity: 200);
        var fadeImage = GetComponent<Image>();
        fadeImage.enabled = true;
        var c = fadeImage.color;
        c.a = 1.0f;
        fadeImage.color = c;

        DOTween.ToAlpha(
            () => fadeImage.color,
            color =>  fadeImage.color = color, 0f, 1f);
        Invoke("SetActive", 1);
      //  fadeoutflag = false;
     //   quitapp = GetComponent<QuitApp>();
    }
    void SetActive()
    {
        var fadeImage = GetComponent<Image>();
        fadeImage.enabled = false;
    }
    public void Update()
    {
        if (fadeoutflag)
        {
            var fadeImage = GetComponent<Image>();
            fadeImage.enabled = true;
            var c = fadeImage.color;
            c.a = 0f;
            fadeImage.color = c;

            DOTween.ToAlpha(
                () => fadeImage.color,
                color => fadeImage.color = color, 1.0f, 2f)
                 .SetLink(gameObject);
            Invoke("FlagManagement", 2);
          //  Invoke("FlagManagement", 1);
        }
    }
    public void FlagManagement()
    {
        fadeoutflag = false;
    }
}
