using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 12f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator animator;
    private SpriteRenderer spriteRenderer; // 스프라이트 렌더러 추가

    public bool delay;
    private float time;
    private int timer = 1;
    public GameObject spawner;

    public float laserRange = 6f;
    public float DownlaserRange = 2.5f;
    public float debugDistance = 0.3f;
    private LayerMask platformLayerMask;

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
        raycast();
        if (delay == true)
        {
            time += Time.deltaTime;
            if (timer < time)
            {
                time = 0;
                delay = false;
                speed = 10;

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

    private void OnCollisionEnter2D(Collision2D other)
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