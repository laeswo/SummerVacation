using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fivedie_gohome : MonoBehaviour
{
    private int go = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            go += 1;
        }
    }
}
