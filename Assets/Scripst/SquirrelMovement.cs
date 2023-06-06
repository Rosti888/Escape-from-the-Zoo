using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class SquirrelMovement : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rigidBody;
    public Transform groundCheck;
    public AudioSource audioSource;

    public float groundCheckRadius = 0.05f;
    public float speed = 2f;
    public float jumpForce = 10f;
    public float glidingSpeed;
    private float initialGravityScale;
    private GameObject keyObject = null;
    public BoxCollider2D rightCollider;
    public bool isOnBeaver;

    public LayerMask collisionMask;
    public LayerMask animalsMask;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        initialGravityScale = rigidBody.gravityScale;
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
        var glidingInput = Input.GetButton("Jump");

        if (glidingInput && rigidBody.velocity.y <= 0)
        {
            animator.SetBool("Fly", true);
            rigidBody.gravityScale = 0;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, -glidingSpeed);
        }
        else
        {
            animator.SetBool("Fly", false);
            rigidBody.gravityScale = initialGravityScale;
        }

        rigidBody.velocity = new Vector2(inputX * speed, rigidBody.velocity.y);

        if (jumpInput && IsGrounded())
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
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
            isOnBeaver = true;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();           
        }
    }

    public void ResetParent()
    {
        isOnBeaver = false;
        transform.SetParent(null);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
    }

    public  bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionMask) != null;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Key") && keyObject == null)
        {
            keyObject = other.gameObject;
        }

        if (other.gameObject.name.Equals("platformupdown") || other.gameObject.name.Equals("platformleftright"))
        {
            ContactPoint2D[] contacts = other.contacts;
            foreach (ContactPoint2D contact in contacts)
            {
                if (contact.normal == Vector2.up)
                {
                    this.transform.parent = other.transform;
                    break;
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Cage") && keyObject != null && rightCollider.enabled)
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("Cage");
            keyObject.SetActive(false);
            keyObject = null;
            rightCollider.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cage") && keyObject != null && rightCollider.enabled)
        {
            audioSource.Play();
            collision.gameObject.GetComponent<Animator>().SetTrigger("Cage");
            keyObject.SetActive(false);
            keyObject = null;
            rightCollider.enabled = false;
            Physics2D.queriesStartInColliders = true;
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