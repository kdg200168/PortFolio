using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TimeLimit : MonoBehaviour
{
    public  static float time = 300f;
    public AudioClip sound1;
    public AudioClip sound2;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {

        //タイム
       time -= 1f * Time.deltaTime;
        if (time <= 2)
        {
           if(audioSource.isPlaying == false)
            {
             audioSource.PlayOneShot(sound1);
             audioSource.PlayOneShot(sound2);
            }
        }
        if (time <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }

    }
}