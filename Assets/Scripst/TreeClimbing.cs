using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeClimbing : MonoBehaviour
{
    private float vertical;
    public float speed;
    private bool isLadder;
    private bool isClimbing;

    public CharacterSwitch characterSwitch;
    public Rigidbody2D rigidBody;

    void Update()
    {
        if (characterSwitch.currentIndex == 0)
        {
            vertical = Input.GetAxisRaw("Vertical");

            if (isLadder && Mathf.Abs(vertical) > 0f)
            {
                isClimbing = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rigidBody.gravityScale = 0f;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, vertical * speed);
        }
        else
        {
            rigidBody.gravityScale = 4f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tree"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Tree"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}