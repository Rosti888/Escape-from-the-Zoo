using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityMonitor : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public Vector2 velocity;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();   
    }

    void FixedUpdate()
    {
        _rigidbody.velocity = velocity;
    }
}
