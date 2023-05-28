using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaverMovement : MonoBehaviour
{
    public Animator Animations;
    public Rigidbody2D _rigidbody;
    public Transform groundCheck;

    public float groundCheckRadius = 0.05f;
    public float speed = 2f;
    public float jumpForce = 10f;
    private float _initialGravityScale;

    public LayerMask collisionMask;
    public LayerMask animalsMask;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _initialGravityScale = _rigidbody.gravityScale;
    }

    void Update()
    {

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

        _rigidbody.velocity = new Vector2(inputX * speed, _rigidbody.velocity.y);

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

        RaycastHit2D[] results = new RaycastHit2D[1];
        ContactFilter2D contactFilter2D = new ContactFilter2D();
        contactFilter2D.SetLayerMask(animalsMask);
        Debug.DrawLine(transform.position, transform.position + transform.up * -.1f, Color.green, 100f);
        if (Physics2D.Raycast(transform.position, transform.position - transform.up, contactFilter2D, results, .1f) > 0)
        {
            Debug.Log(results[0].collider.name);
            Debug.Log("I'm on an animal");
            Transform newParent = null;
            newParent = results[0].collider.transform;
            transform.SetParent(newParent);
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.simulated = false;
        }
    }

    public void ResetParent()
    {
        transform.SetParent(null);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.simulated = true;
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