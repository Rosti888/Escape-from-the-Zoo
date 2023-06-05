using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaverMovement : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rigidBody;
    public Transform groundCheck;

    public float groundCheckRadius = 0.05f;
    public float speed = 2f;
    public float jumpForce = 10f;

    public CharacterSwitch characterSwitch;

    public LayerMask collisionMask;
    public LayerMask animalsMask;

    public bool isOnBoar;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
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

        rigidBody.velocity = new Vector2(inputX * speed, rigidBody.velocity.y);

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
        RaycastHit2D[] results = new RaycastHit2D[1];
        ContactFilter2D contactFilter2D = new ContactFilter2D();
        contactFilter2D.SetLayerMask(animalsMask);
        Debug.DrawLine(transform.position, transform.position + transform.up * -.1f, Color.green, 100f);
        if (Physics2D.Raycast(transform.position, transform.position - transform.up, contactFilter2D, results, .1f) > 0)
        {
            Transform newParent = null;
            newParent = results[0].collider.transform;
            transform.SetParent(newParent);
            isOnBoar = true;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
        }
    }

    public void ResetParent()
    {
        isOnBoar = false;
        transform.SetParent(null);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
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
}