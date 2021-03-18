using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respownpoint : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
      GetComponent<WarpPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
       // SeManager seManager = SeManager.Instance;
      
     //   seManager.SettingPlaySE8();
        WarpPoint.pos = this.transform.position;
    }
}
