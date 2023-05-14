using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject water;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            rb.bodyType = RigidbodyType2D.Static;
            RestartLevel();
        }

        if (collision.gameObject.CompareTag("WaterZone"))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), water.GetComponent<Collider2D>());
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
