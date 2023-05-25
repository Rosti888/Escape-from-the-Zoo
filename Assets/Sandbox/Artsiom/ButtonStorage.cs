using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStorage : MonoBehaviour
{
    public GameObject storageBarrier;
    public GameObject buttonOff;
    public Animator storageAnim;

    private void Start()
    {
        storageAnim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            storageAnim.SetBool("IsOpenning", true);
            storageBarrier.SetActive(false);
            buttonOff.SetActive(false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            buttonOff.SetActive(true);
        }
    }
}