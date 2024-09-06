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
    private SpriteRenderer spriteRenderer; // ��������Ʈ ������ �߰�

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
        spriteRenderer = GetComponent<SpriteRenderer>(); // ��������Ʈ ������ �ʱ�ȭ
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
        float move = Input.GetAxisRaw("Horizontal"); // GetAxisRaw ������� �ﰢ���� �Է� ó��
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        // ���� ��ȯ
        if (move > 0)
        {
            spriteRenderer.flipX = false; // �������� �ٶ�
        }
        else if (move < 0)
        {
            spriteRenderer.flipX = true; // ������ �ٶ�
        }

        // ���� ó��
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false; // ���� ���̹Ƿ� ���鿡 ���� ����
        }
    }

    private void Animate()
    {
        float move = Input.GetAxisRaw("Horizontal"); // GetAxisRaw ������� �ﰢ���� �Է� ó��

        // �ȱ� �ִϸ��̼� ����
        animator.SetBool("walk", move != 0); // move�� 0�� �ƴ� ��쿡�� �ȱ� �ִϸ��̼� ����

        // ���� �ִϸ��̼� ����
        animator.SetBool("jump", !isGrounded); // isGrounded ���¿� ���� ���� �ִϸ��̼� ����
    }

    private void raycast()
    {

        // �������� ����� ���� ��ġ�� �����ϱ�
        Vector2 direction = spriteRenderer.flipX ? Vector2.left : Vector2.right;
        Vector2 startPosition = transform.position;

        int layerMask = LayerMask.GetMask("Target");


        // �÷��̾� �����ϰ� ���???
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