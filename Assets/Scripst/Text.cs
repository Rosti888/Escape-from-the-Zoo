using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour
{
    public TutorialTip tutorialTip;
    public SpriteRenderer tipSpriteRenderer;
    public int counter;

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
        if (counter < 1)
        {
            if (collision.gameObject.name == tutorialTip.gameObjectName)
            {
                StartCoroutine(Deactivate());
                tipSpriteRenderer.enabled = true;
            }
        }
    }

    private IEnumerator Deactivate()
    {
        counter++;
        yield return new WaitForSeconds(5f);
        tipSpriteRenderer.enabled = false;
    }
}
