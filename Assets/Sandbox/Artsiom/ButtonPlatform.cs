using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlatform : MonoBehaviour
{
    public GameObject button;
    public GameObject platform;
    public Transform pointStart, pointEnd;
    public float speed;

    private Vector2 targetPos;

    void Start()
    {
        targetPos = pointStart.position;
    }

    void Update()
    {
        platform.transform.position = Vector2.MoveTowards(platform.transform.position, targetPos, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            targetPos = pointEnd.position;
            button.SetActive(false);
        }

        else
        {
            targetPos = pointStart.position;
            button.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            targetPos = pointStart.position;
            button.SetActive(true);
        }
    }
}