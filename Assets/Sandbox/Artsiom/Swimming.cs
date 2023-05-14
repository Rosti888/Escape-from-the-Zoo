using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swimming : MonoBehaviour
{
    private Animator Animations;

    void Start()
    {
        Animations = GetComponentInChildren<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WaterZone"))
        {
            Animations.SetBool("IsSwimming", true);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            Animations.SetBool("IsSwimming", false);
        }
    }
}
