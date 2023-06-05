using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarMovement : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rigidBody;
    public Transform groundCheck;
    public GameObject obstacle;
    public Animator animObstacle;

    public float groundCheckRadius = 0.05f;
    public float speed = 2f;
    public float jumpForce = 10f;

    private bool canDash = true;
    public bool isDashing;
    public float dashingVelocity = 4f;
    public float dashingTime = 0.3f;
    private float dashingCooldown = 1f;

    public LayerMask collisionMask;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canDash && IsGrounded())
        {
            StartCoroutine(Dash());
        }


        var inputX = Input.GetAxisRaw("Horizontal");

        if (inputX == 0)
        {
            animator.SetBool("IsRunning", false);
        }

        else

        {
            animator.SetBool("IsRunning", true);
        }

        var jumpInput = Input.GetButtonDown("Jump");

        if (!isDashing)
        {
            rigidBody.velocity = new Vector2(inputX * speed, rigidBody.velocity.y);
        }

        if (jumpInput && IsGrounded())
        {
            animator.SetBool("IsJumping", true);
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
        }

        else
        {
            animator.SetBool("IsJumping", false);
        }

        if (inputX != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(inputX), 1, 1);
        }
    }

    public void DisableMovementAnimation()
    {
        animator.SetBool("IsRunning", false);
    }
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionMask);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("platformupdown") || collision.gameObject.name.Equals("platformleftright"))
        {
            ContactPoint2D[] contacts = collision.contacts;
            foreach (ContactPoint2D contact in contacts)
            {
                if (contact.normal == Vector2.up)
                {
                    this.transform.parent = collision.transform;
                    break;
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("platformupdown") || collision.gameObject.name.Equals("platformleftright"))
        {
            this.transform.parent = null;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") && isDashing)
        {
            obstacle.SetActive(false);
            animObstacle.SetBool("IsDestroying", true);
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rigidBody.gravityScale;
        rigidBody.gravityScale = 0f;
        animator.SetBool("IsDashing", true);
        rigidBody.velocity = new Vector2(transform.localScale.x * dashingVelocity, 0f);
        yield return new WaitForSeconds(dashingTime);
        animator.SetBool("IsDashing", false);
        rigidBody.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
