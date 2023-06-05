using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private bool isSquirrelAtFinish;
    private bool isBeaverAtFinish;
    private bool isBoarAtFinish;

    void FixedUpdate()
    {
        if (isSquirrelAtFinish == true && isBeaverAtFinish == true && isBoarAtFinish == true)
        {
            StartCoroutine(FinishLine());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.layer == 3)
            {
                isSquirrelAtFinish = true;
            }

            if (collision.gameObject.layer == 8)
            {
                isBeaverAtFinish = true;
            }

            if (collision.gameObject.layer == 9)
            {
                isBoarAtFinish = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.layer == 3)
            {
                isSquirrelAtFinish = false;
            }

            if (collision.gameObject.layer == 8)
            {
                isBeaverAtFinish = false;
            }

            if (collision.gameObject.layer == 9)
            {
                isBoarAtFinish = false;
            }
        }
    }

    private IEnumerator FinishLine()
    {
        yield return new WaitForSeconds(2f);

        if (isSquirrelAtFinish == true && isBeaverAtFinish == true && isBoarAtFinish == true)
        {
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}