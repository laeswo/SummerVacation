using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    public bool gogo = false;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gogo)
        {
            if (transform.rotation.y<100)
            {
                transform.Rotate(new Vector3(0,0,1));
            }
            else
            {
                transform.rotation = Quaternion.Euler(0,0,0);
                gogo = false;
            }
        }
    }

}
