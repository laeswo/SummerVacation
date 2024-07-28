using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
   public float speed = 10f;
       public float jumpForce = 5f;
       private Rigidbody2D rb;
       private bool isGrounded;
    
   
       void Start()
       {
           rb = GetComponent<Rigidbody2D>();
       }


    void Update()
    {
        Move();

    }

    private void Move()
    {
        float move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
             
        }
    }

}
