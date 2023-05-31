using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarMovement : MonoBehaviour
{
    public Animator Animations;
    public Rigidbody2D _rigidbody;
    public Transform groundCheck;
    public GameObject Obstacle;
    public Animator AnimObstacle;

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
        _rigidbody = GetComponent<Rigidbody2D>();
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
            Animations.SetBool("IsRunning", false);
        }

        else

        {
            Animations.SetBool("IsRunning", true);
        }

        var jumpInput = Input.GetButtonDown("Jump");

        if (!isDashing)
        {
            _rigidbody.velocity = new Vector2(inputX * speed, _rigidbody.velocity.y);
        }

        if (jumpInput && IsGrounded())
        {
            Animations.SetBool("IsJumping", true);
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
        }

        else
        {
            Animations.SetBool("IsJumping", false);
        }

        if (inputX != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(inputX), 1, 1);
        }
    }

    public void DisableMovementAnimation()
    {
        Animations.SetBool("IsRunning", false);
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
            Obstacle.SetActive(false);
            AnimObstacle.SetBool("IsDestroying", true);
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = _rigidbody.gravityScale;
        _rigidbody.gravityScale = 0f;
        Animations.SetBool("IsDashing", true);
        _rigidbody.velocity = new Vector2(transform.localScale.x * dashingVelocity, 0f);
        yield return new WaitForSeconds(dashingTime);
        Animations.SetBool("IsDashing", false);
        _rigidbody.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
