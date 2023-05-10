using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityMonitor : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody.velocity = velocity;
    }
}
