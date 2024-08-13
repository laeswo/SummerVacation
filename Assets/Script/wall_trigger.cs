using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public come_wall come;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            come.char_triger = true;
        }
    }
}
