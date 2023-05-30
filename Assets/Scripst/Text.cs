using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour
{
    public TutorialTip tutorialTip;
    public SpriteRenderer tipSpriteRenderer;

    private void Start()
    {
        tipSpriteRenderer.sprite = tutorialTip.tipSprite;
        if (tutorialTip.isTipEnabledOnStart)
        {
            tipSpriteRenderer.enabled = true;
        }
        else
        {
            tipSpriteRenderer.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == tutorialTip.gameObjectName) 
        {
            tipSpriteRenderer.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == tutorialTip.gameObjectName) 
        {
            tipSpriteRenderer.enabled = false; 
        }
    }
}
