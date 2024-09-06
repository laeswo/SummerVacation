using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Fake_item : MonoBehaviour
{
    public Character player;

    public GameObject effect;

 
    // Start is called before the first frame update
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
            
            Instantiate(effect,transform.position,Quaternion.identity);
            player.speed *= -3;
            Destroy(gameObject);
            player.delay = true;
        }
    }
}
