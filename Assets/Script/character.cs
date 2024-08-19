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

    public bool delay;
    private float time;
    private int timer = 1;
    public GameObject spawner;
    public bool touch = false;

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
        while (touch)
        {
            transform.position = spawner.transform.position;
            if (transform.position.y == spawner.transform.position.y)
            {
                touch = false;
            }
        }
    }

    private void Move()
    {
        float move = Input.GetAxisRaw("Horizontal"); // GetAxisRaw 사용으로 즉각적인 입력 처리
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

        // 점프 처리
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false; // 점프 중이므로 지면에 닿지 않음
        }
    }

    private void Animate()
    {
        float move = Input.GetAxisRaw("Horizontal"); // GetAxisRaw 사용으로 즉각적인 입력 처리

        // 걷기 애니메이션 설정
        animator.SetBool("walk", move != 0); // move가 0이 아닌 경우에만 걷기 애니메이션 실행

        // 점프 애니메이션 설정
        animator.SetBool("jump", !isGrounded); // isGrounded 상태에 따라 점프 애니메이션 설정
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if(other.gameObject.CompareTag("fall"))
        {
            Debug.Log("DDD");
            touch = true;
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