using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject button;
    public GameObject door;
    //public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            door.SetActive(false);
            button.SetActive(false);
            //anim.SetBool("isOpen", true);
        }

        else
        {
            door.SetActive(true);
            button.SetActive(true);
            //anim.SetBool("isOpen", false);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            door.SetActive(true);
            button.SetActive(true);
            //anim.SetBool("isOpen", false);
        }
    }
}
