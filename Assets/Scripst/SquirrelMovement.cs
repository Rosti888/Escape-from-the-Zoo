using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelMovement : MonoBehaviour
{
    public Animator Animations;
    public Rigidbody2D _rigidbody;
    public Transform groundCheck;

    public float groundCheckRadius = 0.05f;
    public float speed = 2f;
    public float jumpForce = 10f;
    public float glidingSpeed;
    private float _initialGravityScale;

    public LayerMask collisionMask;

    void Start()
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
        var glidingInput = Input.GetButton("Jump");

        if (glidingInput && _rigidbody.velocity.y <= 0)
        {
            Animations.SetBool("Fly", true);
            _rigidbody.gravityScale = 0;
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, -glidingSpeed);
        }

        else
        {
            Animations.SetBool("Fly", false);
            _rigidbody.gravityScale = _initialGravityScale;
        }

        _rigidbody.velocity = new Vector2(inputX * speed, _rigidbody.velocity.y);

        if (jumpInput && IsGrounded())
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
        }
        if (inputX != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(inputX), 1, 1);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionMask);
    }
}