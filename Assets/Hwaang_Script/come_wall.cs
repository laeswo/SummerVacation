using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class come_wall : MonoBehaviour
{
    public bool char_triger;
    private character player;
    public Transform spawner;

    public float speed;
    private float yend;
    public float gofloat;

    private bool bahyang;
    // Start is called before the first frame update
    void Start()
    {
        yend = transform.position.y + 3;
        if (gofloat > transform.position.x)
        {
            bahyang = true;
        }
        else
        {
            bahyang = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("이으아아아아아"+char_triger);
        if (char_triger)
        {
            
            if(transform.position.y < yend)
            {
                transform.position += new Vector3(0,0.03f,0);
            }
            else
            {
                if (bahyang)
                {
                    if (transform.position.x < gofloat ) 
                    {
                        transform.position += new Vector3(speed,0,0);
                    }
                    else
                    {Debug.Log("삐용삐용");
                        transform.position = spawner.transform.position;
                        char_triger = false;
                    }
                }
                else
                {
                    if (transform.position.x > gofloat ) 
                    {
                        transform.position += new Vector3(-speed,0,0);
                    }
                    else
                    {
                        transform.position = spawner.transform.position;
                        char_triger = false;
                    }  
                }
                
            }
        }
    }

  

   
}
