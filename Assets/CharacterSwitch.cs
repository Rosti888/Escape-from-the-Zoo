using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    // Define the characters

    public PlatformMovement Squirrel;
    public PlatformMovement Beaver;
    public PlatformMovement Boar;

    public GameObject[] characters;

    private void Start()
    {
        Squirrel.enabled = true;
        Beaver.enabled = false;
        Boar.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        // Switch characters
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Pressed 1 : Squirrel");
            //currentChar = 0;
            Squirrel.enabled = true;
            Beaver.enabled = false;
            Boar.enabled = false;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Pressed 2 : Beaver");
            //currentChar = 1;
            Squirrel.enabled = false;
            Beaver.enabled = true;
            Boar.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Pressed 3 : Boar");
            //currentChar = 2;
            Squirrel.enabled = false;
            Beaver.enabled = false;
            Boar.enabled = true;
        }
    }
}
