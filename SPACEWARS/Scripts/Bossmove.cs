using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossmove : MonoBehaviour
{
    public float movespeed = 10F;

    // Update is called once per frame
    void Update()
    {
        this.transform.position += transform.forward * movespeed * Time.deltaTime;
    }
}
