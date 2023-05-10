using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    public SquirrelMovement Squirrel;
    public BeaverMovement Beaver;
    public BoarMovement Boar;

    public GameObject[] characters;

    private void Start()
    {
        Squirrel.enabled = true;
        Beaver.enabled = false;
        Boar.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Squirrel.enabled = true;
            Beaver.enabled = false;
            Boar.enabled = false;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Squirrel.enabled = false;
            Beaver.enabled = true;
            Boar.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Squirrel.enabled = false;
            Beaver.enabled = false;
            Boar.enabled = true;
        }
    }
}
