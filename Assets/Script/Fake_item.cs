using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Fake_item : MonoBehaviour
{
    public character player;

    public GameObject effect;

 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            
            Instantiate(effect,transform.position,Quaternion.identity);
            player.speed -= 3;
            Destroy(gameObject);
            player.delay = true;
        }
       
    }

   
}
