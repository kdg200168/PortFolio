using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{

    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;
    public AudioClip sound5;
    public AudioClip sound6;
    public AudioClip sound7;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

    }
    void PlaySound1 ()
    {
         audioSource.PlayOneShot(sound1);
    }
    void PlaySound2()
    {
        audioSource.PlayOneShot(sound2);
    }
    void PlaySound3()
    {
        audioSource.PlayOneShot(sound3);
    }
    void PlaySound4()
    {
        audioSource.PlayOneShot(sound4);

    }
    void PlaySound5()
    {
        audioSource.PlayOneShot(sound5);

    }
    void PlaySound6()
    {
        audioSource.PlayOneShot(sound6);
    }
    void PlaySound7()
    {
        audioSource.PlayOneShot(sound7);
    }
}
