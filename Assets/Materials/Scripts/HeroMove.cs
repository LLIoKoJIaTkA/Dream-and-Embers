using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{

    [SerializeField] private float speed = 10.0f; // �������� ��������
    //[SerializeField] private int lives = 5; // ���-�� ������
    [SerializeField] private float jumpForce = 15.0f; // ���� ������

    private bool isGrounded;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb.gravityScale = 3.0f;
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private States state
    {
        get { 
            return (States)anim.GetInteger("state"); 
        }
        set { 
            anim.SetInteger("state", (int)value);  
        }
    }

    private void FixedUpdate()
    {
        if (!isGrounded) state = States.jump;
    }

    private void Update()
    {
        if (isGrounded) state = States.idle;

        if (Input.GetButton("Horizontal"))
            Run();
        if (isGrounded && Input.GetButtonDown("Jump"))
            Jump();
    }

    private void Run()
    {
        if (isGrounded) state = States.run;

        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f; // ��� ��������� �����, ���� �� ����� � ������ ������
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnTriggerStay2D(Collider2D col) // �����������, ����� ��������� �� ��������� ������ ���������� Ground
    {
        if (col.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col) // �����������, ����� ��������� �� ������� �� ���������� Ground
    {
        if (col.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public enum States
    {
        idle,
        run,   
        jump
    }

}
