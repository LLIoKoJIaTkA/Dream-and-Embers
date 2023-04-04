using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeroMove : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f; 
    [SerializeField] private float jumpForce = 15.0f; 

    private bool isGrounded;
    private bool isFlip;
    private SpriteRenderer sprite;
    private Animator anim;
    private Vector3 moveVec;    
    private Rigidbody2D rb; 
    public Vector2 position;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        Run();
        position.x = rb.position.x;
        position.y = rb.position.y;
    }


    #region InputSystem

    public void OnMove(InputValue input)
    {
        Vector2 inputVec = input.Get<Vector2>();
        moveVec = new Vector3(inputVec.x, 0, inputVec.y);
        if (moveVec.x < 0.0f) isFlip = true;
        if (moveVec.x > 0.0f) isFlip = false;
    }

    public void OnJump()
    {
        if (isGrounded)
            Jump();
    }

    #endregion InputSystem



    #region Movement

    private void Jump()
    {
        Debug.LogFormat("dfhd");
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
    private void Run()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + moveVec, speed * Time.deltaTime);

        if (isFlip) sprite.flipX = true;
        else sprite.flipX = false;
    }

    #endregion Movement



    #region TriggerCollider

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

    #endregion TriggerCollider



    #region Animation

    private void UpdateAnimation()
    {
        if (isGrounded) state = States.idle;
        if (!isGrounded) state = States.jump;
        if (isGrounded && moveVec != Vector3.zero) state = States.run;
    }

    public enum States
    {
        idle,
        run,
        jump
    }

    private States state
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }

    #endregion Animation
}