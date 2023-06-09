using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDoor : MonoBehaviour
{
    public GameObject button;
    public GameObject door;
    public Animator anim;
    public new BoxCollider2D collider;
    public AudioSource audioSource;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
            collider.enabled = false;
            button.SetActive(false);
            anim.SetBool("isOpen", true);
        }

        else
        {
            collider.enabled = true;
            button.SetActive(true);
            anim.SetBool("isOpen", false);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collider.enabled = true;
            button.SetActive(true);
            anim.SetBool("isOpen", false);
        }
    }
}
