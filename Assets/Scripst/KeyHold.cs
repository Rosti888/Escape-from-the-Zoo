using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHold : MonoBehaviour
{
    public bool hold;
    public float distance = 1f;
    RaycastHit2D hit;
    public Transform holdPoint;
    public float throwObject = 2;
    public SpriteRenderer displaySprite; 

    void Update()
    {
        if (!hold)
        {
            Physics2D.queriesStartInColliders = false;
            hit = Physics2D.Raycast(transform.position + Vector3.up * 0.5f, Vector2.right * transform.localScale.x, distance);

            if (hit.collider != null && hit.collider.tag == "Key")
            {
                displaySprite.enabled = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    hold = true;
                    displaySprite.enabled = false; 
                }
            }
            else
            {
                displaySprite.enabled = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.collider != null && hit.collider.CompareTag("Cage"))
                {
                    hold = false;
                    Physics2D.queriesStartInColliders = true;
                    if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                    {
                        hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwObject;
                    }
                }
            }
        }

        if (hold)
        {
            hit.collider.gameObject.transform.position = holdPoint.position;

            if (holdPoint.position.x > transform.position.x)
            {
                hit.collider.gameObject.transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
            }
            else if (holdPoint.position.x < transform.position.x)
            {
                hit.collider.gameObject.transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y * -1);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + Vector3.up * 0.3f, transform.position + (Vector3.right * transform.localScale.x + Vector3.up * 0.3f) * distance);
    }
}
