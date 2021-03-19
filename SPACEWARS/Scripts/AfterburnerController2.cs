using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class AfterburnerController2 : MonoBehaviour
{


    //他で使うかもしれないのでParticleSystemを指定してますが以下コードで問題なければGameObjectに書き直してもいいです。
    [SerializeField]
    ParticleSystem pObject = default;

    //ここでパーティクルが停止される時間を指定
    float particleDelayTime = .2f;

    void Awake()
    {
        pObject.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Z) && pObject.isPlaying)
        {
            pObject.gameObject.SetActive(false);
            pObject.Simulate(4.0f, true, false); //追記
            pObject.Stop(); //追記
            StartCoroutine(delay(particleDelayTime, () => {
                pObject.gameObject.SetActive(true);
            }));
            //for Debug
           // Debug.Log("L");
        }
    }

    IEnumerator delay(float waitTime, UnityAction action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}