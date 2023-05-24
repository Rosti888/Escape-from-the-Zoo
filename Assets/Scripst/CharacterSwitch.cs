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
            Beaver.enabled = false;
            Boar.DisableMovementAnimation();
            Beaver._rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            Boar.enabled = false;
            Boar._rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Squirrel.enabled = false;
            Squirrel._rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            Squirrel.DisableMovementAnimation();
            Boar.DisableMovementAnimation();
            Beaver.enabled = true;
            Beaver._rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            Boar.enabled = false;
            Boar._rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Squirrel.enabled = false;
            Squirrel._rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            Squirrel.DisableMovementAnimation();
            Beaver.DisableMovementAnimation();
            Beaver.enabled = false;
            Beaver._rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            Boar.enabled = true;
            Boar._rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
