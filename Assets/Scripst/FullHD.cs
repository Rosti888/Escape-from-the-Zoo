using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullHD : MonoBehaviour
{
    void Start()
    {       
        Screen.SetResolution(1920, 1080, FullScreenMode.ExclusiveFullScreen);
    }
}
