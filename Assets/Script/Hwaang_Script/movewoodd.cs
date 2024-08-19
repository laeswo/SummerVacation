using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movewoodd : MonoBehaviour
{
    // Start is called before the first frame update
    public float start;
    public float end;
    public bool arrive;
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (arrive)
        {
         if(transform.position.x > start)
         {
             transform.position -= new Vector3(0.01f, 0, 0);
         }
         else
         {
             arrive = false;
         }
        }
        else
        {
            if (transform.position.x < end)
            {
                transform.position += new Vector3(0.01f, 0, 0);
            }
            else
            {
                arrive = true;
            }
        }

        

    }
}
