using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 20f;
    public float borderThickness = 10f;
    public float lLimit, rLimit;

    void Update()
    {
        Vector3 pos = transform.position;

        pos.z = -10;

        if (Input.mousePosition.x >= Screen.width - borderThickness)
        {
            pos.x += speed * Time.deltaTime;
        }

        if (Input.mousePosition.x <= borderThickness)
        {
            pos.x -= speed * Time.deltaTime;
        }

        pos.x = Mathf.Clamp(pos.x, lLimit, rLimit);

        transform.position = pos;
    }
}