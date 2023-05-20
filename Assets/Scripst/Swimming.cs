using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swimming : MonoBehaviour
{
    private Animator Animations;
    private new CapsuleCollider2D collider;
    private float originalSizeX;
    private float originalSizeY;
    private Vector2 originalOffset;

    void Start()
    {
        Animations = GetComponentInChildren<Animator>();
        collider = GetComponent<CapsuleCollider2D>();

        originalSizeX = collider.size.x;
        originalSizeY = collider.size.y;
        originalOffset = collider.offset;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WaterZone"))
        {
            Animations.SetBool("IsSwimming", true);
            collider.size = new Vector2(1.660827f, 0.24444f); 
            collider.offset = new Vector2(0.3223473f, 0.11550f); 
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            Animations.SetBool("IsSwimming", false);
            collider.size = new Vector2(1.660827f, 0.764586f); 
            collider.offset = new Vector2(0.3223473f, 0.375589f); 
        }
    }
}