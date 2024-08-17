using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    public float speed;
    public float jumpForce = 6f;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    public bool delay;
    private float time;
    private int timer = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        speed = 1f;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void Update()
    {
        Debug.Log(speed);
        float moveHorizontal = Input.GetAxis("Horizontal");

        if (isGrounded)
        {

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
            rb.AddForce(movement * speed);

        }

        if (moveHorizontal != 0)
        {
            //animator.SetBool("walk", true);
        }
        else
        {
            // animator.SetBool("walk", false);
        }

        if (isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)))
        {
            // animator.SetBool("jump", true);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        else
        {
            //Wz` animator.SetBool("jump", false);
        }
        if (delay == true)
        {
            time += Time.deltaTime;
            if (timer < time)
            {
                time = 0;
                delay = false;
                speed = 1;

            }
        }
    }
}