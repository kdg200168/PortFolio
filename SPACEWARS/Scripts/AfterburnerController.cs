using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class AfterburnerController : MonoBehaviour
{


   
    [SerializeField]
    ParticleSystem pObject = default;

    //ここでパーティクルが停止される時間を指定
    float particleDelayTime = .2f;

    void Awake()
    {
        pObject.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && pObject.isStopped)
        {
            pObject.gameObject.SetActive(true);
            pObject.Simulate(4.0f, true, false); //追記
            pObject.Play(); //追記
            StartCoroutine(delay(particleDelayTime, () => {
                pObject.gameObject.SetActive(false);
            }));
            //for Debug
            //Debug.Log("A");
        }
    }

    IEnumerator delay(float waitTime, UnityAction action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}