using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
   public float speed = 10f;
   public float jumpForce = 5f;
   private Rigidbody2D rb;

    public float laserRange = 6f;
    public float DownlaserRange = 2.5f;
    public float debugDistance = 0.3f;

    private SpriteRenderer spriteRenderer;
    private LayerMask platformLayerMask;

    private bool isGrounded;


    
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        platformLayerMask = LayerMask.GetMask("Ground");
    }


    void Update()
    {
        Move();
        raycast();

    }

    private void Move()
    {
        float move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector3(move * speed, rb.velocity.y,0);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce,0);
             
        }

        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
      
        }
    }



    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
         
        }
    }

    private void raycast()
    {

        // 레이저의 방향과 시작 위치를 설정하기
        Vector2 direction = spriteRenderer.flipX ? Vector2.left : Vector2.right;
        Vector2 startPosition = transform.position;

        int layerMask = LayerMask.GetMask("Target");


        // 플레이어 점프하고도 쏘기???
        if (!isGrounded)
        {
            RaycastHit2D downHit = Physics2D.Raycast(startPosition, Vector2.down, DownlaserRange, platformLayerMask);
            Debug.DrawRay(startPosition, Vector2.down * DownlaserRange, Color.magenta);
        }
    }



}
