using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{

    public float liftForce = 10f; 
    private Rigidbody2D playerRb;

    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Player"))
        {
            playerRb = other.GetComponent<Rigidbody2D>();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
  
        if (other.CompareTag("Player"))
        {
            
            playerRb.gravityScale = 0f;
            playerRb.velocity = new Vector2(playerRb.velocity.x, liftForce);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            playerRb.gravityScale = 1f;
            playerRb = null;
        }
    }
}
