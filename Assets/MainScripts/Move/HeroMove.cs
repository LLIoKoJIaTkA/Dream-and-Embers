using MainScripts.Stats;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MainScripts.Move
{
    public class HeroMove : HeroStats
    {
        private SpriteRenderer sprite;
        private Vector3 moveVec;    
        private Rigidbody2D rb; 
        private bool isGrounded;
        protected bool isFlip;
        private float startPointJump;
        protected bool isAttack = false;
        
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            sprite = GetComponentInChildren<SpriteRenderer>();
        }

        private void Update()
        {
            UpdateAnimation();
        }

        private void FixedUpdate()
        {
            if (rb.position.y >= startPointJump + jumpUpSize)
                StopJump();
            Run();
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
            {
                startPointJump = rb.position.y;
                Jump();
            }                
        }

        #endregion InputSystem


        #region Movement

        private void StopJump()
        {
            rb.AddForce(transform.up * (-jumpForce / 4), ForceMode2D.Impulse);
        }

        private void Jump()
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

        private void Run()
        {
            transform.position = Vector3.MoveTowards(
                transform.position, 
                transform.position + moveVec, 
                speed * Time.deltaTime
            );

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
            if (isGrounded && !isAttack) StateAnimation = States.Idle;
            else if (!isGrounded && !isAttack) StateAnimation = States.Jump;
            else if (isGrounded && !isAttack && moveVec != Vector3.zero) StateAnimation = States.Run;
            else if (isGrounded && isAttack) StateAnimation = States.Attack;
        }

        #endregion Animation
    }
}