using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roatation : MonoBehaviour
{
    public bool good;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (good)
        {
            transform.Rotate(new Vector3(0f, 0, -0.05f));
        }
        else
        {
            transform.Rotate(new Vector3(0f, 0, 0.05f));
        }
    }
}
