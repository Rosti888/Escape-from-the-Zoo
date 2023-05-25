using UnityEngine;

public class ButtonPlatform : MonoBehaviour
{
    public GameObject buttonOff1;
    public GameObject buttonOff2;
    public GameObject platform;
    public Transform pointStart, pointEnd;
    public float speed;
    public bool isButton1Pressed;
    public bool isButton2Pressed;

    private Vector2 targetPos;

    void Start()
    {
        targetPos = pointStart.position;
    }

    void Update()
    {
        platform.transform.position = Vector2.MoveTowards(platform.transform.position, targetPos, speed * Time.deltaTime);

        if (isButton1Pressed || isButton2Pressed)
        {
            targetPos = pointEnd.position;
        }
        else
        {
            targetPos = pointStart.position;
        }

        if (isButton1Pressed)
        {
            buttonOff1.SetActive(false);
        }
        else
        {
            buttonOff1.SetActive(true);
        }

        if (isButton2Pressed)
        {
            buttonOff2.SetActive(false);
        }
        else
        {
            buttonOff2.SetActive(true);
        }
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //targetPos = pointEnd.position;
            isButton1Pressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isButton1Pressed = false;

        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //targetPos = pointEnd.position;
            isButton2Pressed = true;

        }
    }


    /*
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //targetPos = pointEnd.position;
            isButton1Pressed = true;
        }
    }
    */

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isButton2Pressed = false;
            buttonOff2.SetActive(true);
        }
    }
}