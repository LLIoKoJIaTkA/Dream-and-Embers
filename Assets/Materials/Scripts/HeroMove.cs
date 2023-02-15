using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{

    [SerializeField] private float speed = 10.0f; // Скорость движения
    //[SerializeField] private int lives = 5; // Кол-во жизней
    [SerializeField] private float jumpForce = 15.0f; // Сила прыжка

    private bool isGrounded;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 3.0f;
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void FixedUpdate()
    {

    }

    private void Update()
    {
        if (Input.GetButton("Horizontal"))
            Run();
        if (isGrounded && Input.GetButtonDown("Jump"))
            Jump();
    }

    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f; // Для разворота перса, если он бежит в другую строну
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnTriggerStay2D(Collider2D col) // Срабатывает, когда коллайдер ГГ находится внутри коллайдера Ground
    {
        if (col.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col) // Срабатывает, когда коллайдер ГГ выходит из коллайдера Ground
    {
        if (col.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
