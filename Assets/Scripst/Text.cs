using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour
{
    public SpriteRenderer displaySprite; 
    private bool isColliding; 

    private void Start()
    {
        displaySprite.enabled = false; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            isColliding = true; 
            displaySprite.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            isColliding = false; 
            displaySprite.enabled = false; 
        }
    }
}
