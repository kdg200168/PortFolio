using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeBossScene : MonoBehaviour
{
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
       Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.z >= 20000)
        {
            Invoke("GoToBOSS", 1.5f);
        }
    }
    void GoToBOSS()
    {
        SceneManager.LoadScene("BossScene");
    }
}

