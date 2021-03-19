using UnityEngine;
using System.Collections;

public class Bulletlifetime : MonoBehaviour
{
    public float lifetime;
    private GameObject particle;
    void Start()
    {
        Destroy(gameObject, lifetime);
      
    }
}