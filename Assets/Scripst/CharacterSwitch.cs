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
        Squirrel._rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        Beaver.enabled = false;
        Beaver._rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        Boar.enabled = false;
        Boar._rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Squirrel.enabled = true;
            Squirrel._rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            Beaver.DisableMovementAnimation();
            Squirrel.ResetParent();
            Boar.DisableMovementAnimation();
            Beaver._rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            Boar._rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            Beaver.enabled = false;
            Boar.enabled = false;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Squirrel._rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            Squirrel.DisableMovementAnimation();
            Squirrel.enabled = false;
            Boar.DisableMovementAnimation();
            Beaver.enabled = true;
            Beaver._rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            Boar._rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            Boar.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Squirrel._rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            Squirrel.DisableMovementAnimation();
            Squirrel.enabled = false;
            Beaver.DisableMovementAnimation();
            Beaver._rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            Beaver.enabled = false;
            Boar.enabled = true;
            Boar._rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}