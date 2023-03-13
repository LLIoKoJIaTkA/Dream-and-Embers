using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{

    [SerializeField] private float speed = 10.0f; // �������� ��������
    //[SerializeField] private int lives = 5; // ���-�� ������
    [SerializeField] private float jumpForce = 5.0f; // ���� ������
    private bool isGrounded = false;
    public float rayDistance = 0.3f; // ��� �������� ����� ��� ������

    private Rigidbody2D rb;  
    private SpriteRenderer sprite;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        CheckGrounded();
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal"))
            Run();
        if (/*isGrounded &&*/ Input.GetButtonDown("Jump"))
            Jump();
    }

    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f; // ��� ��������� �����, ���� �� ����� � ������ ������
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGrounded()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = collider.Length > 1;
        /*RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.down, rayDistance, LayerMask.GetMask("Ground"));
        isGrounded = hit.collider != null ? true : false;*/
    }

}
