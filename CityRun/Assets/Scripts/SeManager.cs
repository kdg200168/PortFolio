using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeManager : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSourceSE;
    public AudioClip se1;
    public AudioClip se2;
    public AudioClip se3;
    public AudioClip se4;
    public AudioClip se5;
    public AudioClip se6;
    public AudioClip se7;
    public AudioClip se8;
    public AudioClip se9;
    public AudioClip se10;

    public static SeManager Instance
    {
        get; private set;
    }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        audioSourceSE = this.GetComponent<AudioSource>();
    }

    public void SettingPlaySE1()
    {
        audioSourceSE.PlayOneShot(se1);
    }
    public void SettingPlaySE2()
    {
        audioSourceSE.PlayOneShot(se2);
    }
    public void SettingPlaySE3()
    {
        audioSourceSE.PlayOneShot(se3);
    }
    public void SettingPlaySE4()
    {
        audioSourceSE.PlayOneShot(se4);
    }
    public void SettingPlaySE5()
    {
        audioSourceSE.PlayOneShot(se5);
    }
    public void SettingPlaySE6()
    {
        audioSourceSE.PlayOneShot(se6);
    }
    public void SettingPlaySE7()
    {
        audioSourceSE.PlayOneShot(se7);
    }
    public void SettingPlaySE8()
    {
        audioSourceSE.PlayOneShot(se8);
    }
    public void SettingPlaySE9()
    {
        audioSourceSE.PlayOneShot(se9);
    }
    public void SettingPlaySE10()
    {
        audioSourceSE.PlayOneShot(se10);
    }

}
