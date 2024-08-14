using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator animator;
    private SpriteRenderer spriteRenderer; // 스프라이트 렌더러 추가

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // 스프라이트 렌더러 초기화
    }

    void Update()
    {
        Move();
        Animate();
    }

    private void Move()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        // 방향 전환
        if (move > 0)
        {
            spriteRenderer.flipX = false; // 오른쪽을 바라봄
        }
        else if (move < 0)
        {
            spriteRenderer.flipX = true; // 왼쪽을 바라봄
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false; // 점프 중이므로 지면에 닿지 않음
        }
    }

    private void Animate()
    {
        float move = Input.GetAxis("Horizontal");

        // 걷기 애니메이션 설정
        animator.SetBool("walk", move != 0);

        // 점프 애니메이션 설정
        animator.SetBool("jump", !isGrounded);
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
}