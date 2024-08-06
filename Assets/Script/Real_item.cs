using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Real_item : MonoBehaviour
{
    public GameObject effect;

    public cango cg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            cg.cango1 += 1;
            Instantiate(effect,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
